using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private readonly IRepositorioVeiculo repositorioVeiculo;
        private readonly IRepositorioGrupoDeVeiculo repositorioGrupoDeVeiculo;

        private TabelaVeiculoControl? tabelaVeiculoControl;
        private readonly ServicoVeiculo servicoVeiculo;

        public ControladorVeiculo(IRepositorioVeiculo repositorioVeiculo, IRepositorioGrupoDeVeiculo repositorioGrupoDeVeiculo,
            ServicoVeiculo servicoVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
            this.repositorioGrupoDeVeiculo = repositorioGrupoDeVeiculo;
            this.servicoVeiculo = servicoVeiculo;
        }


        public override void Inserir()
        {
            var grupoVeiculo = repositorioGrupoDeVeiculo.SelecionarTodos();

            var tela = new TelaCadastroVeiculoForm(grupoVeiculo);
            tela.Veiculo = new Veiculo();
            tela.GravarRegistro = servicoVeiculo.Inserir;
            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }

        public override void Editar()
        {
            Veiculo VeiculoSelecionado = ObtemVeiculoSelecionado();

            if (VeiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro",
                "Edição de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var grupoVeiculo = repositorioGrupoDeVeiculo.SelecionarTodos();

            TelaCadastroVeiculoForm tela = new TelaCadastroVeiculoForm(grupoVeiculo);

            tela.Veiculo = VeiculoSelecionado.Clone();

            tela.GravarRegistro = servicoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Excluir()
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro",
               "Edição de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o veiculo?",
                "Exclusão de veiculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                repositorioVeiculo.Excluir(veiculoSelecionado);

            CarregarVeiculos();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaVeiculoControl == null)
                tabelaVeiculoControl = new TabelaVeiculoControl();

            CarregarVeiculos();

            return tabelaVeiculoControl;
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxVeiculo();
        }

        private Veiculo ObtemVeiculoSelecionado()
        {
            var id = tabelaVeiculoControl.ObtemIdVeiculoSelecionado();

            return repositorioVeiculo.SelecionarPorId(id);
        }

        private void CarregarVeiculos()
        {
            List<Veiculo> veiculos = repositorioVeiculo.SelecionarTodos();
            tabelaVeiculoControl?.AtualizarRegistros(veiculos);
            if(veiculos.Count >= 2)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} veiculos(s)");
            }
            else
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} veiculo.");

        }




    }
}
