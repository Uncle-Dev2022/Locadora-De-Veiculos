using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        Locacao locacao;
        private List<Funcionario> Funcionarios;
        private List<Cliente> Clientes;
        private List<Condutor> Condutores;
        private List<GrupoDeVeiculo> GruposDeVeiculos;
        private List<Veiculo> Veiculos;
        private List<PlanoDeCobranca> PlanosDeCobrancas;
        private List<Taxa> Taxas;

        public TelaCadastroLocacaoForm(List<Cliente> clientes,List<Condutor> Condutores,List<GrupoDeVeiculo> gruposDeVeiculos,List<Veiculo> veiculos)
        {
            InitializeComponent();
            this.Clientes = clientes;
            this.Condutores = Condutores;
            this.GruposDeVeiculos = gruposDeVeiculos;
            this.Veiculos = veiculos;
            CarregarCliente(clientes);
            CarregarGruposDeVeiculos(GruposDeVeiculos);
        }


        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        public Locacao _locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;

                comboBoxCliente.SelectedItem = locacao.cliente;
                textBoxNome.Text = locacao.Nome;
                textBoxEndereco.Text = locacao.Endereco;
                maskedTextBoxCPF.Text = locacao.CPF;
                maskedTextBoxCNH.Text = locacao.CNH;
                textBoxEmail.Text = locacao.Email;

            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            locacao.cliente = (Cliente)comboBoxCliente.SelectedItem;
            locacao.Nome = textBoxNome.Text;
            locacao.Endereco = textBoxEndereco.Text;
            locacao.CPF = maskedTextBoxCPF.Text;
            locacao.CNH = maskedTextBoxCNH.Text;
            locacao.Email = textBoxEmail.Text;

            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void ClienteEhCondutor_CheckedChanged(object sender, EventArgs e)
        {
            Cliente clienteSelecionado = (Cliente)comboBoxCliente.SelectedItem;

            if (clienteSelecionado != null && clienteSelecionado.tipoCliente == true && CheckBoxClienteEhCondutor.Checked == true)
            {
                textBoxNome.Text = clienteSelecionado.Nome;
                textBoxEndereco.Text = clienteSelecionado.Endereco;
                maskedTextBoxCPF.Text = clienteSelecionado.CPF_CNPJ;
                maskedTextBoxCNH.Text = clienteSelecionado.CNH;
                textBoxEmail.Text = clienteSelecionado.Email;
            }
            else
            {
                textBoxNome.Clear();
                textBoxEndereco.Clear();
                maskedTextBoxCPF.Clear();
                maskedTextBoxCNH.Clear();
                textBoxEmail.Clear();
            }
        }

        private void CarregarCliente(List<Cliente> clientes)
        {
            comboBoxCliente.Items.Clear();

            foreach (var cliente in clientes)
            {
                comboBoxCliente.Items.Add(cliente);
            }
        }

        private void CarregarCondutores(List<Condutor> condutores,Cliente cliente)
        {
            comboBoxCliente.Items.Clear();

            foreach (var condutor in condutores)
            {
                if(condutor.cliente.Id==cliente.Id)
                {
                    comboBoxCondutor.Items.Add(condutor);
                }
            }
        }

        private void CarregarGruposDeVeiculos(List<GrupoDeVeiculo> GruposDeVeiculos)
        {
            comboBoxCliente.Items.Clear();

            foreach (var grupoDeVeiculo in GruposDeVeiculos)
            {
                comboBoxGrupoDeVeiculo.Items.Add(grupoDeVeiculo);
            }
        }

        private void CarregarVeiculos(List<Veiculo> Veiculos,GrupoDeVeiculo grupodeveiculo)
        {
            comboBoxCliente.Items.Clear();

            foreach (var veiculo in Veiculos)
            {
                if(veiculo.GrupoDeVeiculo.Id==grupodeveiculo.Id)
                {
                    comboBoxVeiculo.Items.Add(veiculo);
                }
            }
        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente clienteSelecionado = (Cliente)comboBoxCliente.SelectedItem;

            if (comboBoxCliente.SelectedItem != null && clienteSelecionado.tipoCliente == true)
                CheckBoxClienteEhCondutor.Enabled = true;
            else
            {
                CheckBoxClienteEhCondutor.Checked = false;
                CheckBoxClienteEhCondutor.Enabled = false;

                textBoxNome.Clear();
                textBoxEndereco.Clear();
                maskedTextBoxCPF.Clear();
                maskedTextBoxCNH.Clear();
                textBoxEmail.Clear();
            }
        }
    }
}
