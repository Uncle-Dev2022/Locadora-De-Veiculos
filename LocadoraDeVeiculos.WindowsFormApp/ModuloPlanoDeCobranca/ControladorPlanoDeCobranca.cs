using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
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
        private readonly IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;
        private readonly ServicoPlanoDeCobranca servicoPlanoDeCobranca;
        private TabelaPlanoDeCobrancaControl tabelaPlanoDeCobranca;

        public ControladorPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca, ServicoPlanoDeCobranca servicoPlanoDeCobranca)
        {
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
        }
        public override void Inserir()
        {
            TelaCadastroPlanoDeCobrancaForm tela = new TelaCadastroPlanoDeCobrancaForm();
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
            PlanoDeCobranca planoDeCobrancaSelecionado = ObtemPlanoDeCobrancaSelecionado();

            if (planoDeCobrancaSelecionado == null)
            {
                MessageBox.Show("Selecione um Plano de Cobrança primeiro",
                "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroPlanoDeCobrancaForm tela = new TelaCadastroPlanoDeCobrancaForm();

            tela.Plano = planoDeCobrancaSelecionado;

            tela.GravarRegistro = servicoPlanoDeCobranca.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanosDeCobranca();
            }
        }

        public override void Excluir()
        {
            PlanoDeCobranca planoDeCobrancaSelecionado = ObtemPlanoDeCobrancaSelecionado();

            if (planoDeCobrancaSelecionado == null)
            {
                MessageBox.Show("Selecione um Plano de Cobrança primeiro",
                "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir um Plano de Cobrança?",
                "Exclusão de Plano de Cobrança", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioPlanoDeCobranca.Excluir(planoDeCobrancaSelecionado);
                CarregarPlanosDeCobranca();
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
            List<PlanoDeCobranca> planosDeCobranca = repositorioPlanoDeCobranca.SelecionarTodos();

            tabelaPlanoDeCobranca.AtualizarRegistros(planosDeCobranca);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {planosDeCobranca.Count} Plano(s) De Cobrança");
        }
        private PlanoDeCobranca ObtemPlanoDeCobrancaSelecionado()
        {
            var numero = tabelaPlanoDeCobranca.ObtemNumeroPlanoDeCobrancaSelecionado();

            return repositorioPlanoDeCobranca.SelecionarPorId(numero);
        }
    }
}
