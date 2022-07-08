using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloPlanoDeCobranca
{
    public partial class TelaCadastroPlanoDeCobranca : Form
    {
        PlanoDeCobranca plano;

        public TelaCadastroPlanoDeCobranca()
        {
            InitializeComponent();
        }

        public Func<PlanoDeCobranca, ValidationResult> GravarRegistro { get; set; }

        public PlanoDeCobranca Plano
        {
            get { return plano; }
            set
            {
                plano = value;
                textBoxNome.Text = plano.Nome;
                TextBoxDiarioValorDiario.Text = plano.planoDiario.valorDiario.ToString();
                TextBoxDiarioValorKM.Text = plano.planoDiario.valorKm.ToString();

                TextBoxLivreValorDiario.Text = plano.planoLivre.valorDiario.ToString();

                TextBoxControladoValorDiario.Text = plano.planoControlado.valorDiario.ToString();
                TextBoxControladoValorKM.Text = plano.planoControlado.valorKm.ToString();
                TextBoxLimiteKM.Text = plano.planoControlado.limiteKm.ToString();

                comboBox1.SelectedItem = plano.grupoDeVeiculo;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            plano.Nome = textBoxNome.Text;

            plano.grupoDeVeiculo = comboBox1.SelectedItem as GrupoDeVeiculo;

            plano.planoLivre.valorDiario = Convert.ToDecimal(TextBoxLivreValorDiario.Text);

            plano.planoDiario.valorDiario = Convert.ToDecimal(TextBoxDiarioValorDiario.Text);
            plano.planoDiario.valorKm = Convert.ToDecimal(TextBoxDiarioValorKM.Text);

            plano.planoControlado.valorKm = Convert.ToDecimal(TextBoxControladoValorKM.Text);
            plano.planoControlado.limiteKm = Convert.ToDecimal(TextBoxLimiteKM);
            plano.planoControlado.valorDiario = Convert.ToDecimal(TextBoxControladoValorDiario.Text);

            var resultadoValidacao = GravarRegistro(plano);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
