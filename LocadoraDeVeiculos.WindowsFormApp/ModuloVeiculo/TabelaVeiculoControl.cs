﻿using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloVeiculo
{
    public partial class TabelaVeiculoControl : UserControl
    {
        public TabelaVeiculoControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoDeVEiculo", HeaderText = "Grupo De VEiculo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "Cor"},
                new DataGridViewTextBoxColumn { DataPropertyName = "AnoModelo", HeaderText = "Ano Modelo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "TipoCombustivel", HeaderText = "Tipo Combustivel"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placal"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Quilometragem", HeaderText = "Quilometragem"},
                new DataGridViewTextBoxColumn { DataPropertyName = "CapacidadeTanque", HeaderText = "Capacidade Tanque"},
                new DataGridViewImageColumn { DataPropertyName = "Imagem", HeaderText = "Imagem", ImageLayout = DataGridViewImageCellLayout.Stretch, Width = 50}
            };
            return colunas;
        }

        public Guid ObtemIdVeiculoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Veiculo> veiculos)
        {
            grid.Rows.Clear();

            foreach (var veiculo in veiculos)
            {
                grid.Rows.Add(veiculo.Id, veiculo.GrupoDeVeiculo.Nome, veiculo.Marca, veiculo.Modelo, veiculo.Cor,
                    veiculo.AnoModelo, veiculo.TipoCombustivel, veiculo.Placa,
                    veiculo.Quilometragem, veiculo.CapacidadeTanque, veiculo.Imagem);
            }
        }





    }
}
