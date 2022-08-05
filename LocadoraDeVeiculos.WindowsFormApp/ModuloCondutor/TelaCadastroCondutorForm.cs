using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloCondutor
{
    public partial class TelaCadastroCondutorForm : Form
    {
        Condutor condutor;
        private List<Cliente> Clientes;

        public TelaCadastroCondutorForm(List<Cliente> clientes)
        {
            InitializeComponent();
            this.Clientes = clientes;
            CarregarCliente(clientes);
        }


        public Func<Condutor, Result<Condutor>> GravarRegistro { get; set; }

        public Condutor _condutor
        {
            get { return condutor; }
            set
            {
                condutor = value;

                comboBoxCliente.SelectedItem = condutor.cliente;
                textBoxNome.Text = condutor.Nome;
                textBoxEndereco.Text = condutor.Endereco;
                maskedTextBoxCPF.Text = condutor.CPF;
                maskedTextBoxCNH.Text = condutor.CNH;
                textBoxEmail.Text = condutor.Email;

            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            condutor.cliente = (Cliente)comboBoxCliente.SelectedItem;
            condutor.Nome = textBoxNome.Text;
            condutor.Endereco = textBoxEndereco.Text;
            condutor.CPF = maskedTextBoxCPF.Text;
            condutor.CNH = maskedTextBoxCNH.Text;
            condutor.Email = textBoxEmail.Text;

            var resultadoValidacao = GravarRegistro(condutor);

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
        }

        private void CarregarCliente(List<Cliente> clientes)
        {
            comboBoxCliente.Items.Clear();

            foreach (var cliente in clientes)
            {
                comboBoxCliente.Items.Add(cliente);
            }
        }
        private void CarregarClienteFisico(List<Cliente> clientes)
        {
            comboBoxCliente.Items.Clear();

            foreach (var cliente in clientes)
            {
                if (cliente.tipoCliente == true)
                    comboBoxCliente.Items.Add(cliente);
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
