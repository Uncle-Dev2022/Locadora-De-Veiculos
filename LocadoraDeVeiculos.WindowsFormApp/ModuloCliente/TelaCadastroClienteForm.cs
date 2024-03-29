﻿using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
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

        public Func<Cliente, Result<Cliente>> GravarRegistro { get; set; }

        public Cliente _cliente
        {
            get { return cliente; }
            set
            {
                cliente = value;

                txtNome.Text = cliente.Nome;
                txtBoxEndereço.Text = cliente.Endereco;
                txtBoxEmail.Text = cliente.Email;
                maskedTextBoxTelefone.Text = cliente.Telefone;

                if (cliente.tipoCliente == true)
                {
                    radioButtonPessoaFiscia.Checked = true;
                    cpfEcnpj.Text = "CPF";
                    maskedTextBoxCNPJ.Visible = false;
                    maskedTextBoxCPF.Visible = true;
                    labelCnh.Visible = true;
                    maskedTextBoxCNH.Visible = true;
                    maskedTextBoxCPF.Text = cliente.CPF_CNPJ;
                }
                else
                {
                    radioButtonPessoaJuridica.Checked = true;
                    cpfEcnpj.Text = "CNPJ";
                    maskedTextBoxCNPJ.Visible = true;
                    maskedTextBoxCPF.Visible = false;
                    labelCnh.Visible = false;
                    maskedTextBoxCNH.Visible = false;
                    maskedTextBoxCNPJ.Text = cliente.CPF_CNPJ;
                }
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
            cpfEcnpj.Text = "CPF";
            maskedTextBoxCNPJ.Visible = false;
            maskedTextBoxCPF.Visible = true;
            labelCnh.Visible = true;
            maskedTextBoxCNH.Visible = true;
        }

        private void ConfigurarCamposPessoaJuridica()
        {
            cpfEcnpj.Text = "CNPJ";
            maskedTextBoxCNPJ.Visible = true;
            maskedTextBoxCPF.Visible = false;
            labelCnh.Visible = false;
            maskedTextBoxCNH.Visible = false;
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            cliente.Nome = txtNome.Text;
            cliente.Endereco = txtBoxEndereço.Text;
            cliente.Email = txtBoxEmail.Text;
            cliente.Telefone = maskedTextBoxTelefone.Text;

            if (radioButtonPessoaFiscia.Checked)
            {
                cliente.tipoCliente = true;
                cliente.CNH = maskedTextBoxCNH.Text;
                cliente.CPF_CNPJ = maskedTextBoxCPF.Text;
            }
            else
            {
                cliente.tipoCliente = false;
                cliente.CPF_CNPJ = maskedTextBoxCNPJ.Text;
            }

            var resultadoValidacao = GravarRegistro(cliente);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(erro);
                    
                }
                DialogResult = DialogResult.None;
            }
        }

        private void maskedTextBoxCNPJ_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void TelaCadastroClienteForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
