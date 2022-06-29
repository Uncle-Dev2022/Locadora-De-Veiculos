using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionário;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        
        

        public Func<Funcionario, ValidationResult> GravarRegistro { get; set; }

        public Funcionario _funcionario
        {
            

            get { return funcionario; }
            set
            {
                funcionario = value;
                

                txtBoxFuncionarioNome.Text = funcionario.Nome;

                txtBoxFuncionarioSalario.Text = funcionario.Salario.ToString();

                
                dateTimePickerDataAdmissao.Value = funcionario.DataAdmissao;

                txtBoxFuncionarioSenha.Text = funcionario.Senha;

                txtBoxFuncionarioLogin.Text = funcionario.Login;

                checkBoxGerente.Checked = funcionario.Gerente;
            }

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            funcionario.Nome = txtBoxFuncionarioNome.Text;

            funcionario.Salario = Decimal.Parse(txtBoxFuncionarioSalario.Text);

            funcionario.DataAdmissao = dateTimePickerDataAdmissao.Value;

            funcionario.Senha = txtBoxFuncionarioSenha.Text;

            funcionario.Login = txtBoxFuncionarioLogin.Text;

            funcionario.Gerente = checkBoxGerente.Checked;

            var resultadoValidacao = GravarRegistro(funcionario);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void DefinirDataAdmissao()
        {
            dateTimePickerDataAdmissao.MaxDate = DateTime.Today;
        }
    }
}
