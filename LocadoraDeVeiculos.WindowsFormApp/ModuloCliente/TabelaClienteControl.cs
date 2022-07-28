using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloCliente
{
    public partial class TabelaClienteControl : UserControl
    {
        public TabelaClienteControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "ID"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CPFCNPJ", HeaderText = "CPF/CNPJ"},

            };

            return colunas;
        }
        public Guid ObtemNumeroCLienteSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }
        public void AtualizarRegistros(List<Cliente> Clientes)
        {
            grid.Rows.Clear();

            foreach (var cliente in Clientes)
            {
                grid.Rows.Add(cliente.Id, cliente.Nome, cliente.Endereco, cliente.Email, cliente.Telefone, cliente.CPF_CNPJ);
            }
        }
    }
}
