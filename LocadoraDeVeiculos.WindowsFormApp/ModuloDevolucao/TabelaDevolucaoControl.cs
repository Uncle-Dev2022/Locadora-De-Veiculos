using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloDevolucao
{
    public partial class TabelaDevolucaoControl : UserControl
    {
        public TabelaDevolucaoControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Guid", HeaderText = "Guid", MinimumWidth = 185},

                new DataGridViewTextBoxColumn { DataPropertyName = "Funcionario", HeaderText = "Funcionário"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoDeVeiculo", HeaderText = "Grupo De Veículo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veículo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoCobranca", HeaderText = "Plano de cobrança"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataLocacao", HeaderText = "Locação"},                

                new DataGridViewTextBoxColumn { DataPropertyName = "DataDevolucao", HeaderText = "Data De Devolução"},
            };

            return colunas;
        }

        public Guid ObtemNumeroDevolucaoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Devolucao> devolucoes)
        {
            grid.Rows.Clear();

            foreach (var devolucao in devolucoes)
            {
                grid.Rows.Add(devolucao.Id, devolucao.Locacao.funcionario.Nome,
                    devolucao.Locacao.Condutor == null ? devolucao.Locacao.Cliente.Nome : devolucao.Locacao.Condutor.Nome,
                    devolucao.Locacao.veiculo.Modelo,
                    devolucao.Locacao.planoDeCobranca,
                    devolucao.Locacao.dataDeLocacao,
                    devolucao.DataDevolucao);
            }
        }


    }
}
