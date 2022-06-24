using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloGrupoDeVeiculos
{
    public partial class TabelaGrupoDeVeiculoControl : UserControl
    {
        public TabelaGrupoDeVeiculoControl()
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


            };

            return colunas;
        }

        public int ObtemNumeroDisciplinaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<GrupoDeVeiculo> grupoDeVeiculo)
        {
            grid.Rows.Clear();

            foreach (var grupoveiculo in grupoDeVeiculo)
            {
                grid.Rows.Add(grupoveiculo.Id, grupoveiculo.Nome);
            }
        }
    }
}
