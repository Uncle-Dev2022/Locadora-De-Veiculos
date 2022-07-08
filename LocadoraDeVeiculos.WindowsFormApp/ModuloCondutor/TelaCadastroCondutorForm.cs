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

        public TelaCadastroCondutorForm(List<Cliente> clientes)
        {
            InitializeComponent();
            CarregarCliente(clientes);
        }

        private void CarregarCliente(List<Cliente> clientes)
        {
            comboBoxCliente.Items.Clear();

            foreach(var cliente in clientes)
            {
                comboBoxCliente.Items.Add(cliente);
            }
        }

        public Func<Condutor,ValidationResult> GravarRegistro { get; set; }

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
            condutor.cliente= (Cliente)comboBoxCliente.SelectedItem;
            condutor.Nome= textBoxNome.Text;
            condutor.Endereco= textBoxEndereco.Text;
            condutor.CPF= maskedTextBoxCPF.Text;
            condutor.CNH = maskedTextBoxCNH.Text;
            condutor.Email= textBoxEmail.Text;
        }
    }
}
