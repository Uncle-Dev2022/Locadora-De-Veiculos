using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloCliente
{
    public class ControladorCliente :ControladorBase
    {
        private readonly RepositorioClienteEmBancoDeDados repositorioCliente;
        private TabelaClienteControl tabelaCliente;

        public ControladorCliente(RepositorioClienteEmBancoDeDados repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public override void Inserir()
        {
            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();
            tela._cliente = new Cliente();

            tela.GravarRegistro = repositorioCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCliente();
            }
        }

        public override void Editar()
        {
            Cliente ClienteSelecionado = ObtemClienteSelecionado();

            if (ClienteSelecionado == null)
            {
                MessageBox.Show("Selecione um grupo de veículo primeiro",
                "Edição de grupo de veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();

            tela._cliente = ClienteSelecionado;

            tela.GravarRegistro = repositorioCliente.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCliente();
            }
        }

        public override void Excluir()
        {
            Cliente ClienteSelecionado = ObtemClienteSelecionado();

            if (ClienteSelecionado == null)
            {
                MessageBox.Show("Selecione um Cliente primeiro",
                "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir um Cliente?",
                "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioCliente.Excluir(ClienteSelecionado);
                CarregarCliente();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCliente == null)
                tabelaCliente = new TabelaClienteControl();

            CarregarCliente();

            return tabelaCliente;
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCliente();
        }


        private Cliente ObtemClienteSelecionado()
        {
            var numero = tabelaCliente.ObtemNumeroCLienteSelecionado();

            return repositorioCliente.SelecionarPorId(numero);
        }


        private void CarregarCliente()
        {

            List<Cliente> Clientes = repositorioCliente.SelecionarTodos();

            tabelaCliente.AtualizarRegistros(Clientes);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {Clientes.Count} CLiente(s)");
        }


    }
}

