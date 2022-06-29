﻿using System.Collections.Generic;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using System.Windows.Forms;

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
        public int ObtemNumeroTaxaSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Taxa> taxas)
        {
            grid.Rows.Clear();
            
            foreach (var taxa in taxas)
            {
                grid.Rows.Add(taxa.Id, taxa.descricao, taxa.valor * 100);
            }
        }
        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Taxa", HeaderText = "Taxa(%)"},

            };

            return colunas;
        }
    }
}
