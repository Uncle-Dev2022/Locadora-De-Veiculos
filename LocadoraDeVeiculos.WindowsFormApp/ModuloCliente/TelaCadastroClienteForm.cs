using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloCliente
{
    public partial class TelaCadastroClienteForm : Form
    {
        Cliente cliente;

        public TelaCadastroClienteForm()
        {
            InitializeComponent();
        }

        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }

        public Cliente _cliente
        {
            get { return cliente; }
            set
            {
                cliente = value;

                txtBoxNome.Text = cliente.Nome;
                txtBoxEndereço.Text = cliente.Endereco;
                txtBoxEmail.Text = cliente.Email;
                txtBoxTelefone.Text = cliente.Telefone;

                if(cliente.ClienteFisico == true)
                {
                    radioButtonPessoaFiscia.Checked = true;
                    LabelCPF_Cnpj.Text = "CPF";
                    maskedTextBoxCNPJ.Visible = false;
                    maskedTextBoxCPF.Visible = true;
                    labelCnh.Visible = true;
                    txtBoxCNH.Visible = true;
                }
                else
                {
                    radioButtonPessoaJuridica.Checked = true;
                    LabelCPF_Cnpj.Text = "CNPJ";
                    maskedTextBoxCNPJ.Visible = true;
                    maskedTextBoxCPF.Visible = false;
                    labelCnh.Visible = false;
                    txtBoxCNH.Visible = false;
                }
            }

        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            cliente.Nome = txtBoxNome.Text;
            cliente.Endereco = txtBoxEndereço.Text;
            cliente.Email = txtBoxEmail.Text;
            cliente.Telefone = txtBoxTelefone.Text;

            if (radioButtonPessoaFiscia.Checked)
            {
                cliente.ClienteFisico=true;
                cliente.CNH = txtBoxCNH.Text;
                cliente.CPF_CNPJ = maskedTextBoxCPF.Text;
            }
            else
            {
                cliente.ClienteFisico = false;
                cliente.CPF_CNPJ = maskedTextBoxCNPJ.Text;
            }

            var resultadoValidacao = GravarRegistro(cliente);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void radioButtonPessoaFiscia_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurarCamposPessoaFisica();
        }

        private void radioButtonPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurarCamposPessoaJuridica();
        }

        private void ConfigurarCamposPessoaFisica()
        {
            radioButtonPessoaFiscia.Checked = true;
            LabelCPF_Cnpj.Text = "CPF";
            maskedTextBoxCNPJ.Visible = false;
            maskedTextBoxCPF.Visible = true;
            labelCnh.Visible = true;
            txtBoxCNH.Visible = true;
        }

        private void ConfigurarCamposPessoaJuridica()
        {
            radioButtonPessoaJuridica.Checked = true;
            LabelCPF_Cnpj.Text = "CNPJ";
            maskedTextBoxCNPJ.Visible = true;
            maskedTextBoxCPF.Visible = false;
            labelCnh.Visible = false;
            txtBoxCNH.Visible = false;
        }
     
    }
}
