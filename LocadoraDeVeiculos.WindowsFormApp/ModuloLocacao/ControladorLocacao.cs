using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
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

        public ControladorLocacao(ServicoLocacao servicoLocacao)
        {

            this.servicoLocacao = servicoLocacao;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroLocacaoForm();

            tela._funcionario = new Funcionario();

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

            var tela = new TelaCadastroLocacaoForm();

            tela._funcionario = LocacaoSelecionada;

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

