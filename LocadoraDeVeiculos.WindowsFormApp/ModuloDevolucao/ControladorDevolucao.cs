using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloDevolucao;
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

        public ControladorDevolucao(ServicoDevolucao servicoDevolucao, ServicoLocacao servicoLocacao,
            ServicoTaxa servicoTaxa)
        {
            servicoDevolucao = servicoDevolucao;
            servicoLocacao = servicoLocacao;
            servicoTaxa = servicoTaxa;

        }

        public override void Inserir()
        {


            TelaCadastroDevolucaoForms tela = new(servicoDevolucao, servicoLocacao, servicoTaxa);

            tela.Devolucao = new();

            tela.GravarRegistro = servicoDevolucao.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarDevolucoes();
        }



        public override void Editar()
        {
            var id = tabelaDevolucao.ObtemNumeroDevolucaoSelecionado();

            var devolucaoSelecionada = servicoDevolucao.SelecionarPorId(id);

            if (devolucaoSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma devolução para editar");
                return;
            }

            TelaCadastroDevolucaoForms tela = new(servicoDevolucao, servicoLocacao, servicoTaxa);

            tela.Devolucao = devolucaoSelecionada.Value;

            tela.GravarRegistro = servicoDevolucao.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarDevolucoes();
        }





        public override void Excluir()
        {
            var id = tabelaDevolucao.ObtemNumeroDevolucaoSelecionado();

            Devolucao devolucaoSelecionada = servicoDevolucao.SelecionarPorId(id).Value;

            if (devolucaoSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma devolução para excluir");
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a devolução?",
               "Exclusão de Devolução", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            Result validationResult;

            if (resultado == DialogResult.OK)
            {
                validationResult = servicoDevolucao.Excluir(devolucaoSelecionada);
                CarregarDevolucoes();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia.AtualizarRodape(validationResult.Errors[0].Message);
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
            List<Devolucao> devolucoes = servicoDevolucao.SelecionarTodos().Value;

            tabelaDevolucao.AtualizarRegistros(devolucoes);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {devolucoes.Count} {(devolucoes.Count == 1 ? "devolução" : "devoluções")}");
        }

    }
}
