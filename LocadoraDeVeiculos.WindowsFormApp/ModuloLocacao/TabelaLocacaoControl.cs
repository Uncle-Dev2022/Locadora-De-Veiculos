using LocadoraDeVeiculos.Dominio.ModuloLocacao;
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

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloLocacao
{
    public partial class TabelaLocacaoControl : UserControl
    {
        public TabelaLocacaoControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veículo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoDeCobranca", HeaderText = "Plano De Cobrança"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataDeLocacao", HeaderText = "Data De Locação"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataDeDevolucaoPrevista", HeaderText = "Data De Devolução Prevista"},
            };

            return colunas;
        }

        public Guid ObtemNumeroLocacaoSelecionada()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Locacao> locacao)
        {
            grid.Rows.Clear();

            foreach (var funcionario in locacao)
            {
                grid.Rows.Add(funcionario.Id, funcionario.Cliente.Nome, funcionario.veiculo.Marca, funcionario.Condutor.Nome, funcionario.planoDeCobranca.Nome,
                    funcionario.dataDeLocacao, funcionario.dataDeDevolucaoPrevista);
            }
        }
    }
}
