using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
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

        public ControladorGrupoDeVeiculo(RepositorioGrupoDeVeiculoEmBancoDeDados repositorioGrupoDeVeiculo)
        {
            this.repositorioGrupoDeVeiculo = repositorioGrupoDeVeiculo;
        }

        public override void Inserir()
        {
            TelaCadastroGrupoDeVeiculoForm tela = new TelaCadastroGrupoDeVeiculoForm();
            tela.GrupoDeVeiculo = new GrupoDeVeiculo();

            tela.GravarRegistro = repositorioGrupoDeVeiculo.Inserir;

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

            tela.GrupoDeVeiculo = GrupoDeVeiculoSelecionado;

            tela.GravarRegistro = repositorioGrupoDeVeiculo.Editar;

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
            var numero = tabelaGrupoDeVeiculo.ObtemNumeroDisciplinaSelecionada();

            return repositorioGrupoDeVeiculo.SelecionarPorId(numero);
        }


        private void CarregarGrupoDeVeiculo()
        {

            List<GrupoDeVeiculo> grupoDeVeiculo = repositorioGrupoDeVeiculo.SelecionarTodos();

            tabelaGrupoDeVeiculo.AtualizarRegistros(grupoDeVeiculo);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {grupoDeVeiculo.Count} grupo de veículos(s)");
        }


    }
}
