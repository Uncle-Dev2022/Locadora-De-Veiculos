using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private readonly ServicoCliente servicoCliente;
        private TabelaClienteControl tabelaCliente;

        public ControladorCliente(ServicoCliente servicoCliente)
        {
            this.servicoCliente = servicoCliente;
        }

        public override void Inserir()
        {
            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();
            tela._cliente = new Cliente();

            tela.GravarRegistro = servicoCliente.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public override void Editar()
        {
            var id = tabelaCliente.ObtemNumeroCLienteSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Cliente primeiro",
                "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCliente.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
               "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var clienteSelecionado = resultado.Value;

            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();

            tela._cliente = clienteSelecionado;

            tela.GravarRegistro = servicoCliente.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarClientes();
            }

        }

        public override void Excluir()
        {
            var id = tabelaCliente.ObtemNumeroCLienteSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                    "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCliente.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o Cliente?", "Exclusão de Cliente",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCliente.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarClientes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCliente == null)
                tabelaCliente = new TabelaClienteControl();

            CarregarClientes();

            return tabelaCliente;
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCliente();
        }

        private void CarregarClientes()
        {
            var resultado = servicoCliente.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Cliente> Clientes = resultado.Value;

                tabelaCliente.AtualizarRegistros(Clientes);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {Clientes.Count} CLiente(s)");
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

