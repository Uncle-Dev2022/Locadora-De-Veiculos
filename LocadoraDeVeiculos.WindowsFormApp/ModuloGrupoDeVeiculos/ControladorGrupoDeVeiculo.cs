using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloGrupoDeVeiculos
{
    public class ControladorGrupoDeVeiculo : ControladorBase
    {
        private TabelaGrupoDeVeiculoControl tabelaGrupoDeVeiculo;
        private readonly ServicoGrupoDeVeiculo servicoGrupoDeVeiculo;

        public ControladorGrupoDeVeiculo(ServicoGrupoDeVeiculo servicoGrupoDeVeiculo)
        {
            this.servicoGrupoDeVeiculo = servicoGrupoDeVeiculo;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroGrupoDeVeiculoForm();

            tela._grupoDeVeiculo = new GrupoDeVeiculo();

            tela.GravarRegistro = servicoGrupoDeVeiculo.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarGrupoDeVeiculo();
            }
        }

        public override void Editar()
        {
            var id = tabelaGrupoDeVeiculo.ObtemNumeroGrupoDeVeiculoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo de veículo primeiro",
                    "Edição de grupo de veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoGrupoDeVeiculo.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de grupo de veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoVeiculoSelecionado = resultado.Value;

            var tela = new TelaCadastroGrupoDeVeiculoForm();

            tela._grupoDeVeiculo = grupoVeiculoSelecionado.Clone();

            tela.GravarRegistro = servicoGrupoDeVeiculo.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarGrupoDeVeiculo();

        }

        public override void Excluir()
        {
            var id = tabelaGrupoDeVeiculo.ObtemNumeroGrupoDeVeiculoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um grupo de veículo primeiro",
                    "Exclusão de grupo de veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoGrupoDeVeiculo.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de grupo de veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var grupoVeiculoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o grupo de veículo?", "Exclusão de grupo de veículo",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoGrupoDeVeiculo.Excluir(grupoVeiculoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarGrupoDeVeiculo();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de grupo de veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxGrupoDeVeiculo();
        }


        public override UserControl ObtemListagem()
        {
            if (tabelaGrupoDeVeiculo == null)
                tabelaGrupoDeVeiculo = new TabelaGrupoDeVeiculoControl();

            CarregarGrupoDeVeiculo();

            return tabelaGrupoDeVeiculo;
        }


        private void CarregarGrupoDeVeiculo()
        {
            var resultado = servicoGrupoDeVeiculo.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<GrupoDeVeiculo> grupoVeiculos = resultado.Value;

                tabelaGrupoDeVeiculo.AtualizarRegistros(grupoVeiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {grupoVeiculos.Count} Grupo de Veículo(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Grupo de Veículo",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
