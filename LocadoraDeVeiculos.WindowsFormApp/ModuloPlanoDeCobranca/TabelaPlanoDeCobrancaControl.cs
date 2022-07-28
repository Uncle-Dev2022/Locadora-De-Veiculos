using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloPlanoDeCobranca
{
    public partial class TabelaPlanoDeCobrancaControl : UserControl
    {
        public TabelaPlanoDeCobrancaControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoDeVeiculo", HeaderText = "Grupo De Veículo"},

            };

            return colunas;
        }
        public Guid ObtemNumeroPlanoDeCobrancaSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }
        public void AtualizarRegistros(List<PlanoDeCobranca> planosDeCobranca)
        {
            grid.Rows.Clear();

            foreach (var planoDeCobranca in planosDeCobranca)
            {
                grid.Rows.Add(planoDeCobranca.Id, planoDeCobranca.Nome, planoDeCobranca.grupoDeVeiculo.Nome);
            }
        }
    }
}
