using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloDevolucao;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloTaxas;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloDevolucao
{
    public class ControladorDevolucao : ControladorBase
    {
        private ServicoDevolucao servicoDevolucao;
        private ServicoLocacao servicoLocacao;
        private ServicoTaxa servicoTaxa;

        private TabelaDevolucaoControl tabelaDevolucao;

        public ControladorDevolucao(ServicoDevolucao servicoDevolucao,
            ServicoLocacao servicoLocacao, ServicoTaxa servicoTaxa)
        {
            this.servicoDevolucao = servicoDevolucao;
            this.servicoLocacao = servicoLocacao;
            this.servicoTaxa = servicoTaxa;
        }

        public override void Inserir()
        {
            TelaCadastroDevolucaoForms tela = new(servicoDevolucao, servicoLocacao, servicoTaxa);

            tela.Devolucao = new();

            tela.GravarRegistro = servicoDevolucao.Inserir;           

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarDevolucoes();
        }



        public override void Editar()
        {
            var id = tabelaDevolucao.ObtemNumeroDevolucaoSelecionado();
            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Devolição primeiro",
                    "Edição de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            var resultado = servicoDevolucao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var devolucaoSelecionada = resultado.Value;

            TelaCadastroDevolucaoForms tela = new(servicoDevolucao, servicoLocacao, servicoTaxa);

            tela.Devolucao = devolucaoSelecionada;

            tela.GravarRegistro = servicoDevolucao.Editar;
                       

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarDevolucoes();
        }





        public override void Excluir()
        {
            var id = tabelaDevolucao.ObtemNumeroDevolucaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Devolução primeiro",
                    "Exclusão de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoDevolucao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var devolucaoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a Devolução?", "Exclusão de Devolução",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoDevolucao.Excluir(devolucaoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarDevolucoes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolBoxDevolucao();
        }


        public override UserControl ObtemListagem()
        {
            if (tabelaDevolucao == null)
                tabelaDevolucao = new();

            CarregarDevolucoes();

            return tabelaDevolucao;
        }

        private void CarregarDevolucoes()
        {
            var resultado = servicoDevolucao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Devolucao> devolucoes = servicoDevolucao.SelecionarTodos().Value;

                tabelaDevolucao.AtualizarRegistros(devolucoes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {devolucoes.Count} Devolução");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Devolução",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
