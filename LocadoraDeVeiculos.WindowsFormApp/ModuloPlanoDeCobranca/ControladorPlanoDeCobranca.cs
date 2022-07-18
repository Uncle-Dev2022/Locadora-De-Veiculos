using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloGrupoDeVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloPlanoDeCobranca
{
    public class ControladorPlanoDeCobranca : ControladorBase
    {
        private readonly ServicoPlanoDeCobranca servicoPlanoDeCobranca;
        private readonly ServicoGrupoDeVeiculo servicoGrupoDeVeiculo;
        private TabelaPlanoDeCobrancaControl tabelaPlanoDeCobranca;

        public ControladorPlanoDeCobranca(ServicoPlanoDeCobranca servicoPlanoDeCobranca, ServicoGrupoDeVeiculo servicoGrupoDeVeiculo)
        {     
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
            this.servicoGrupoDeVeiculo = servicoGrupoDeVeiculo;
        }
        public override void Inserir()
        {
            var grupos = servicoGrupoDeVeiculo.SelecionarTodos();

            TelaCadastroPlanoDeCobrancaForm tela = new TelaCadastroPlanoDeCobrancaForm(grupos.Value);
            tela.Plano = new PlanoDeCobranca();

            tela.GravarRegistro = servicoPlanoDeCobranca.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanosDeCobranca();
            }
        }


        public override void Editar()
        {
            var id = tabelaPlanoDeCobranca.ObtemNumeroPlanoDeCobrancaSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um PlanoDeCobranca primeiro",
                "Edição de PlanoDeCobranca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoPlanoDeCobranca.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
               "Edição de PlanoDeCobranca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var PlanoDeCobrancaSelecionado = resultado.Value;
            
            var grupos = servicoGrupoDeVeiculo.SelecionarTodos();

            TelaCadastroPlanoDeCobrancaForm tela = new TelaCadastroPlanoDeCobrancaForm(grupos.Value);

            tela.Plano = PlanoDeCobrancaSelecionado;

            tela.GravarRegistro = servicoPlanoDeCobranca.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarPlanosDeCobranca();
            }
        }

        public override void Excluir()
        {
            var id = tabelaPlanoDeCobranca.ObtemNumeroPlanoDeCobrancaSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Plano De Cobrança primeiro",
                    "Exclusão de Plano De Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoPlanoDeCobranca.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Plano De Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o Plano De Cobrança?", "Exclusão de Plano De Cobrança",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoPlanoDeCobranca.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarPlanosDeCobranca();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de PlanoDeCobrancas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxPlanoDeCobranca();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaPlanoDeCobranca == null)
                tabelaPlanoDeCobranca = new TabelaPlanoDeCobrancaControl();

            CarregarPlanosDeCobranca();

            return tabelaPlanoDeCobranca;
        }
        private void CarregarPlanosDeCobranca()
        {
            var resultado = servicoPlanoDeCobranca.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<PlanoDeCobranca> PlanoDeCobrancas = resultado.Value;

                tabelaPlanoDeCobranca.AtualizarRegistros(PlanoDeCobrancas);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {PlanoDeCobrancas.Count} Plano(s) De Cobrança");
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Plano De Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
