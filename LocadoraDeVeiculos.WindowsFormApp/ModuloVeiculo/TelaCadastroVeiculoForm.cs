using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculoForm : Form
    {

        private byte[] imagemSelecionada;

        private Veiculo veiculo;

        public TelaCadastroVeiculoForm(List<Funcionario> grupoVeiculo)
        {
            InitializeComponent();
            CarregarGrupoDeVeiculo(grupoVeiculo);
        }

        private void CarregarGrupoDeVeiculo(List<Funcionario> grupoVeiculo)
        {
            comboBoxGrupoVeiculo.Items.Clear();

            foreach (var item in grupoVeiculo)
            {
                comboBoxGrupoVeiculo.Items.Add(item);
            }
        }

        public Veiculo Veiculo
        {
            get => veiculo;
            set
            {
                veiculo = value;
                    PreencherDadosNaTela();
            }
        }

        public Func<Veiculo, ValidationResult> GravarRegistro { get; set; }




        private void btnGravar_Click(object sender, EventArgs e)
        {
            ObterDadosTela();

            var resultadoValidacao = GravarRegistro(veiculo);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }


        }

        private void PreencherDadosNaTela()
        {
            comboBoxGrupoVeiculo.SelectedItem = veiculo.GrupoDeVeiculo;
            textBoxMarca.Text = veiculo.Marca;
            textBoxModelo.Text = veiculo.Modelo;
            textBoxCor.Text = veiculo.Cor;
            textBoxAno.Text = veiculo.AnoModelo;
            textBoxTipoCombustivel.Text = veiculo.TipoCombustivel;
            textBoxPlaca.Text = veiculo.Placa;
            textBoxQuilometragem.Text = veiculo.Quilometragem.ToString();
            textBoxCapacidade.Text = veiculo.CapacidadeTanque.ToString();
            pictureImagem.Image = veiculo._Imagem;

            imagemSelecionada = veiculo.Imagem;

        }

        private void ObterDadosTela()
        {
            Veiculo.GrupoDeVeiculo = (Funcionario)comboBoxGrupoVeiculo.SelectedItem;
            Veiculo.Marca = textBoxMarca.Text;
            Veiculo.Modelo = textBoxModelo.Text;
            Veiculo.Cor = textBoxCor.Text;
            Veiculo.AnoModelo = textBoxAno.Text;
            Veiculo.TipoCombustivel = textBoxTipoCombustivel.Text;
            Veiculo.Placa = textBoxPlaca.Text;
            Veiculo.Quilometragem = Decimal.Parse(textBoxQuilometragem.Text);
            Veiculo.CapacidadeTanque = Int32.Parse(textBoxCapacidade.Text);

            veiculo.Imagem = imagemSelecionada;

        }

        private void btnImagem_Click(object sender, EventArgs e)
        {
            imagemSelecionada = veiculo.Imagem;

            if (openFileDialogAbrir.ShowDialog() == DialogResult.OK)
            {
                imagemSelecionada = File.ReadAllBytes(openFileDialogAbrir.FileName);

                using (var ms = new MemoryStream(imagemSelecionada))
                    pictureImagem.Image = new Bitmap(ms);
            }
        }
    }
}
