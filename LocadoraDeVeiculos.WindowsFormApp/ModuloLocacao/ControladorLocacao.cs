using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloFuncinario;
using LocadoraVeiculos.Aplicacao.ModuloGrupoDeVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxas;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        private TabelaLocacaoControl tabelaLocacao;
        private readonly ServicoLocacao servicoLocacao;
        private readonly ServicoCliente servicoCliente;
        private readonly ServicoCondutor servicoCondutor;
        private readonly ServicoGrupoDeVeiculo servicoGrupoDeVeiculo;
        private readonly ServicoVeiculo servicoVeiculo;
        private readonly ServicoPlanoDeCobranca servicoPlanoDeCobranca;
        private readonly ServicoTaxa servicoTaxa;
        private readonly ServicoFuncionario servicoFuncionario;

        public ControladorLocacao(ServicoLocacao servicoLocacao,ServicoCliente servicoCliente, ServicoCondutor servicoCondutor,ServicoGrupoDeVeiculo servicoGrupoDeVeiculo,ServicoVeiculo servicoVeiculo,ServicoPlanoDeCobranca servicoPlanoDeCobranca,ServicoTaxa servicoTaxa,ServicoFuncionario servicoFuncionario)
        {
            this.servicoLocacao = servicoLocacao;
            this.servicoCliente = servicoCliente;
            this.servicoCondutor = servicoCondutor;
            this.servicoGrupoDeVeiculo = servicoGrupoDeVeiculo;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
            this.servicoTaxa = servicoTaxa;
            this.servicoFuncionario = servicoFuncionario;
            
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroLocacaoForm(servicoCliente,servicoCondutor,servicoGrupoDeVeiculo,servicoVeiculo,servicoPlanoDeCobranca,servicoTaxa,servicoFuncionario);

            tela._locacao = new Locacao();

            tela.GravarRegistro = servicoLocacao.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarLocacao();
            }
        }

        public override void Editar()
        {
            var id = tabelaLocacao.ObtemNumeroLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Locação primeiro",
                    "Edição de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var LocacaoSelecionada = resultado.Value;

            var tela = new TelaCadastroLocacaoForm(servicoCliente, servicoCondutor, servicoGrupoDeVeiculo, servicoVeiculo, servicoPlanoDeCobranca, servicoTaxa, servicoFuncionario);

            tela._locacao = LocacaoSelecionada;

            tela.GravarRegistro = servicoLocacao.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarLocacao();

        }

        public override void Excluir()
        {
            var id = tabelaLocacao.ObtemNumeroLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Locação primeiro",
                    "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoLocacao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a Locação?", "Exclusão de Locação",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoLocacao.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacao();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaLocacao == null)
                tabelaLocacao = new TabelaLocacaoControl();

            CarregarLocacao();

            return tabelaLocacao;
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxLocacao();
        }

        private void CarregarLocacao()
        {

            var resultado = servicoLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Locacao> locacoes = resultado.Value;

                tabelaLocacao.AtualizarRegistros(locacoes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {locacoes.Count} Locações(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Locação",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}

