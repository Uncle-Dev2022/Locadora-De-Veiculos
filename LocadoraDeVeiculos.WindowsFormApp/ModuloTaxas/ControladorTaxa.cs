using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.ModuloTaxas;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloTaxas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloTaxas
{
    internal class ControladorTaxa : ControladorBase
    {
        private readonly ServicoTaxa servicoTaxa;
        private TabelaTaxasControl tabelaTaxas;

        public ControladorTaxa(ServicoTaxa servicoTaxa)
        {
            this.servicoTaxa = servicoTaxa;
        }
        public override void Editar()
        {
            var id = tabelaTaxas.ObtemNumeroTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Taxa primeiro",
                "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoTaxa.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
               "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var clienteSelecionado = resultado.Value;

            TelaCadastroTaxasForm tela = new TelaCadastroTaxasForm();

            tela.Taxa = clienteSelecionado;

            tela.GravarRegistro = servicoTaxa.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Excluir()
        {
            var id = tabelaTaxas.ObtemNumeroTaxaSelecionada();
            
            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Taxa primeiro",
                    "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoTaxa.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a Taxa?", "Exclusão de Taxa",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoTaxa.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarTaxas();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void Inserir()
        {
            TelaCadastroTaxasForm tela = new TelaCadastroTaxasForm();
            tela.Taxa = new Taxa();

            tela.GravarRegistro = servicoTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTaxas == null)
                tabelaTaxas = new TabelaTaxasControl();

            CarregarTaxas();

            return tabelaTaxas;
        }
        private void CarregarTaxas()
        {
            Result<List<Taxa>> resultado = servicoTaxa.SelecionarTodos();


            if (resultado.IsSuccess)
            {
                List<Taxa> taxas = resultado.Value;

                tabelaTaxas.AtualizarRegistros(taxas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {taxas.Count} Taxa(s)");
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Taxas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}