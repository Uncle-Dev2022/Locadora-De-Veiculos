using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloGrupoDeVeiculos
{
    public class ControladorGrupoDeVeiculo : ControladorBase
    {
        private readonly RepositorioGrupoDeVeiculoEmBancoDeDados repositorioGrupoDeVeiculo;
        private TabelaGrupoDeVeiculoControl tabelaGrupoDeVeiculo;
        private readonly ServicoGrupoDeVeiculo servicoGrupoDeVeiculo;

        public ControladorGrupoDeVeiculo(RepositorioGrupoDeVeiculoEmBancoDeDados repositorioGrupoDeVeiculo, ServicoGrupoDeVeiculo servicoGrupoDeVeiculo)
        {
            this.repositorioGrupoDeVeiculo = repositorioGrupoDeVeiculo;
            this.servicoGrupoDeVeiculo = servicoGrupoDeVeiculo;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroGrupoDeVeiculoForm();
            tela._grupoDeVeiculo = new GrupoDeVeiculo();
            tela.GravarRegistro = servicoGrupoDeVeiculo.Inserir;
            DialogResult resultado = tela.ShowDialog();          

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoDeVeiculo();
            }
        }

        public override void Editar()
        {
            GrupoDeVeiculo GrupoDeVeiculoSelecionado = ObtemGrupoDeVeiculoSelecionado();

            if (GrupoDeVeiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veículo primeiro",
                "Edição de grupo de veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroGrupoDeVeiculoForm tela = new TelaCadastroGrupoDeVeiculoForm();

            tela._grupoDeVeiculo = GrupoDeVeiculoSelecionado.Clone();

            tela.GravarRegistro = servicoGrupoDeVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarGrupoDeVeiculo();
            }
        }

        public override void Excluir()
        {
            GrupoDeVeiculo GrupoDeVeiculoSelecionada = ObtemGrupoDeVeiculoSelecionado();

            if (GrupoDeVeiculoSelecionada == null)
            {
                MessageBox.Show("Selecione um grupo de veículos primeiro",
                "Exclusão de grupo de veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir um grupo de veículos?",
                "Exclusão de grupo de veículos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioGrupoDeVeiculo.Excluir(GrupoDeVeiculoSelecionada);
                CarregarGrupoDeVeiculo();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaGrupoDeVeiculo == null)
                tabelaGrupoDeVeiculo = new TabelaGrupoDeVeiculoControl();

            CarregarGrupoDeVeiculo();

            return tabelaGrupoDeVeiculo;
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxGrupoDeVeiculo();
        }


        private GrupoDeVeiculo ObtemGrupoDeVeiculoSelecionado()
        {
            var numero = tabelaGrupoDeVeiculo.ObtemNumeroGrupoDeVeiculoSelecionada();

            return repositorioGrupoDeVeiculo.SelecionarPorId(numero);
        }


        private void CarregarGrupoDeVeiculo()
        {

            List<GrupoDeVeiculo> grupoDeVeiculo = repositorioGrupoDeVeiculo.SelecionarTodos();

            tabelaGrupoDeVeiculo.AtualizarRegistros(grupoDeVeiculo);

            if (grupoDeVeiculo.Count > 1)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {grupoDeVeiculo.Count} Grupos de Veículo(s)");
            }
            else
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {grupoDeVeiculo.Count} Grupo de Veículo");


        }
    }
}
