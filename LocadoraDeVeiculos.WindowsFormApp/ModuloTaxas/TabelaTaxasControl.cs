using System.Collections.Generic;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using System.Windows.Forms;
using System;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloTaxas
{
    public partial class TabelaTaxasControl : UserControl
    {
        public TabelaTaxasControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }
        public Guid ObtemNumeroTaxaSelecionada()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Taxa> taxas)
        {
            grid.Rows.Clear();
            
            foreach (var taxa in taxas)
            {
                grid.Rows.Add(taxa.Id, taxa.descricao, taxa.valor, taxa.tipoCalculo);
            }
        }
        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Taxa", HeaderText = "Custo:"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo_Calculo", HeaderText = "Tipo Cálculo"},
            };

            return colunas;
        }
    }
}
