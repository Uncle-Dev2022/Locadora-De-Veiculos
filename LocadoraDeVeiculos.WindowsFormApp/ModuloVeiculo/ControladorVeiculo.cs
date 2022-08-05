using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloGrupoDeVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private readonly ServicoVeiculo servicoVeiculo;
        private readonly ServicoGrupoDeVeiculo servicoGrupoVeiculo;

        private TabelaVeiculoControl tabelaVeiculoControl;

        public ControladorVeiculo(ServicoVeiculo servicoVeiculo, ServicoGrupoDeVeiculo servicoGrupoVeiculo)
        {
            this.servicoVeiculo = servicoVeiculo;
            this.servicoGrupoVeiculo = servicoGrupoVeiculo;
        }

        public override void Inserir()
        {
            var grupoVeiculo = servicoGrupoVeiculo.SelecionarTodos();

            if (grupoVeiculo.IsFailed)
            {
                MessageBox.Show(grupoVeiculo.Errors[0].Message,
               "Inserção de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var tela = new TelaCadastroVeiculoForm(grupoVeiculo.Value);

            tela.Veiculo = new Veiculo();

            tela.GravarRegistro = servicoVeiculo.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }

        public override void Editar()
        {
            var id = tabelaVeiculoControl.ObtemIdVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Veículo primeiro",
                "Edição de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var selecaoGrupoVeiculos = servicoGrupoVeiculo.SelecionarTodos();

            if (selecaoGrupoVeiculos.IsFailed)
            {
                MessageBox.Show(selecaoGrupoVeiculos.Errors[0].Message,
               "Edição de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var resultado = servicoVeiculo.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
               "Edição de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultado.Value;

            TelaCadastroVeiculoForm tela = new TelaCadastroVeiculoForm(selecaoGrupoVeiculos.Value);

            tela.Veiculo = veiculoSelecionado;

            tela.GravarRegistro = servicoVeiculo.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarVeiculos();
            }

        }

        public override void Excluir()
        {
            var id = tabelaVeiculoControl.ObtemIdVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veículo primeiro",
                    "Exclusão de veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoVeiculo.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o veículo?", "Exclusão de veículo",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoVeiculo.Excluir(veiculoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarVeiculos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxVeiculo();
        }


        public override UserControl ObtemListagem()
        {
            if (tabelaVeiculoControl == null)
                tabelaVeiculoControl = new TabelaVeiculoControl();

            CarregarVeiculos();

            return tabelaVeiculoControl;
        }

        private void CarregarVeiculos()
        {

            var resultado = servicoVeiculo.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Veiculo> veiculos = resultado.Value;

                tabelaVeiculoControl.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} Veículo(s)");
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
