using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using System;
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

        public Func<Taxa, Result<Taxa>> GravarRegistro { get; set; }

        public Taxa Taxa
        {
            get { return taxa; }
            set
            {
                taxa = value;

                txtNumero.Text = taxa.Id.ToString();
                txtDescricao.Text = taxa.descricao;
                txtValor.Text = taxa.valor.ToString();
                if (taxa.tipoCalculo == TipoCalculo.Diario)
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
            }
        }
        private void btnGravar_Click(object sender, System.EventArgs e)
        {
            if (!double.TryParse(txtValor.Text, out taxa.valor))
                DialogResult = DialogResult.Abort;

            taxa.descricao = txtDescricao.Text;
            if (radioButton1.Checked)
                taxa.tipoCalculo = Enum.Parse<TipoCalculo>(radioButton1.Text);
            else
                taxa.tipoCalculo = Enum.Parse<TipoCalculo>(radioButton2.Text);

            var resultadoValidacao = GravarRegistro(taxa);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
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
