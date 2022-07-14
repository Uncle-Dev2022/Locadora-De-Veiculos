using LocadoraDeVeiculos.Dominio.ModuloFuncionário;
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

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloFuncionário
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Salário", HeaderText = "Salário"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Data de Admissão", HeaderText = "Data de Admissão"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Senha", HeaderText = "Senha"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Login", HeaderText = "Login"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Gerente", HeaderText = "Gerente"},


            };

            return colunas;
        }

        public Guid ObtemNumeroFuncionarioSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            grid.Rows.Clear();

            foreach (var funcionario in funcionarios)
            {
                grid.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.Salario, funcionario.DataAdmissao, funcionario.Senha,
                    funcionario.Login, funcionario.Gerente);
            }
        }
    }
}
