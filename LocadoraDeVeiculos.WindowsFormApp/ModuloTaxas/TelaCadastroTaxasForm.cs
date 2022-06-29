using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloTaxas
{
    public partial class TelaCadastroTaxasForm : Form
    {
        public TelaCadastroTaxasForm()
        {
            InitializeComponent();
        }
        private Taxa taxa;

        public Func<Taxa, ValidationResult> GravarRegistro { get; set; }

        public Taxa Taxa
        {
            get { return taxa; }
            set
            {
                taxa = value;

                txtNumero.Text = taxa.Id.ToString();
                txtDescricao.Text = taxa.descricao;
                txtValor.Text = taxa.valor.ToString();
            }       
        }
        private void btnGravar_Click(object sender, System.EventArgs e)
        {
            if (!double.TryParse(txtValor.Text, out taxa.valor))
                DialogResult = DialogResult.Abort;

            taxa.descricao = txtDescricao.Text;      

            var resultadoValidacao = GravarRegistro(taxa);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroTaxasForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroTaxasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}
