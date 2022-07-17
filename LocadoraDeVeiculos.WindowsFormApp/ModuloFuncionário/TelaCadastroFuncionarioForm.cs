using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloFuncionário
{
    public partial class TelaCadastroFuncionarioForm : Form
    {
        Funcionario funcionario;

        public TelaCadastroFuncionarioForm()
        {
            InitializeComponent();
            DefinirDataAdmissao();
        }              

        public Func<Funcionario, Result<Funcionario>> GravarRegistro { get; set; }

        public Funcionario _funcionario
        {
            

            get { return funcionario; }
            set
            {
                funcionario = value;
                

                txtBoxFuncionarioNome.Text = funcionario.Nome;

                maskedTextBoxSalario.Text = funcionario.Salario.ToString();

                
                dateTimePickerDataAdmissao.Value = funcionario.DataAdmissao;

                txtBoxFuncionarioSenha.Text = funcionario.Senha;

                txtBoxFuncionarioLogin.Text = funcionario.Login;

                checkBoxGerente.Checked = funcionario.Gerente;
            }

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            funcionario.Nome = txtBoxFuncionarioNome.Text;

            funcionario.Salario = Decimal.Parse(maskedTextBoxSalario.Text);

            funcionario.DataAdmissao = dateTimePickerDataAdmissao.Value;

            funcionario.Senha = txtBoxFuncionarioSenha.Text;

            funcionario.Login = txtBoxFuncionarioLogin.Text;

            funcionario.Gerente = checkBoxGerente.Checked;

            var resultadoValidacao = GravarRegistro(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void DefinirDataAdmissao()
        {
            dateTimePickerDataAdmissao.MaxDate = DateTime.Today;
        }

        private void Senha_CheckedChanged(object sender, EventArgs e)
        {
            if(SenhaBox.Checked == true)
            {
                txtBoxFuncionarioSenha.PasswordChar = default;
            }
            else
                txtBoxFuncionarioSenha.PasswordChar = '*';
        }
    }
}
