using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private readonly ServicoCondutor servicoCondutor;
        private readonly ServicoCliente servicoCliente;
        private TabelaCondutorControl tabelaCondutor;

        public ControladorCondutor(ServicoCondutor servicoCondutor, ServicoCliente servicoCliente)
        {
            this.servicoCliente = servicoCliente;
            this.servicoCondutor = servicoCondutor;
        }

        public override void Inserir()
        {

            var selecaoClientes = servicoCliente.SelecionarTodos();

            if (selecaoClientes.IsFailed)
            {
                MessageBox.Show(selecaoClientes.Errors[0].Message,
               "Inserção de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm(selecaoClientes.Value);

            tela._condutor = new Condutor();

            tela.GravarRegistro = servicoCondutor.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarCondutores();
            }
        }

        public override void Editar()
        {
            var id = tabelaCondutor.ObtemNumeroCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Condutor primeiro",
                "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var selecaoClientes = servicoCliente.SelecionarTodos();

            if (selecaoClientes.IsFailed)
            {
                MessageBox.Show(selecaoClientes.Errors[0].Message,
               "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var resultado = servicoCondutor.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
               "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultado.Value;

            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm(selecaoClientes.Value);

            tela._condutor = condutorSelecionado;

            tela.GravarRegistro = servicoCondutor.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarCondutores();
            }

        }

        public override void Excluir()
        {
            var id = tabelaCondutor.ObtemNumeroCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                    "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCondutor.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o Condutor?", "Exclusão de Condutor",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCondutor.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarCondutores();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCondutor == null)
                tabelaCondutor = new TabelaCondutorControl();

            CarregarCondutores();

            return tabelaCondutor;
        }

        private void CarregarCondutores()
        {

            var resultado = servicoCondutor.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Condutor> Condutores = resultado.Value;

                tabelaCondutor.AtualizarRegistros(Condutores);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {Condutores.Count} Condutore(s)");
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Condutores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
