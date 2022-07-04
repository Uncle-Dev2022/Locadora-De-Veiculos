using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private readonly RepositorioCondutorEmBancoDeDados repositorioCondutor;
        private readonly RepositorioClienteEmBancoDeDados repositorioCliente;
        private readonly ServicoCondutor servicoCondutor;
        private TabelaCondutorControl tabelaCondutor;

        public ControladorCondutor(RepositorioCondutorEmBancoDeDados repositorioCondutor,ServicoCondutor servicoCondutor,RepositorioClienteEmBancoDeDados repositorioCliente)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.repositorioCliente = repositorioCliente;
            this.servicoCondutor=servicoCondutor;
        }

        public override void Inserir()
        {
            var clientes = repositorioCliente.SelecionarTodos();

            if (clientes.Count == 0)
            {
                MessageBox.Show("Cadastre um Cliente primeiro",
                   "Cadastro de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm(clientes);
            tela._condutor = new Condutor();

            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutores();
            }
        }
        public override void Editar()
        {
            Condutor CondutorSelecionado = ObtemCondutorSelecionado();
            var clientes = repositorioCliente.SelecionarTodos();

            if (CondutorSelecionado == null)
            {
                MessageBox.Show("Selecione um Condutor primeiro",
                "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (clientes.Count == 0)
            {
                MessageBox.Show("Cadastre um Cliente primeiro",
                   "Cadastro de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            TelaCadastroCondutorForm tela = new TelaCadastroCondutorForm(clientes);

            tela._condutor = CondutorSelecionado;

            tela.GravarRegistro = servicoCondutor.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutores();
            }
        }

        public override void Excluir()
        {
            Condutor CondutorSelecionado = ObtemCondutorSelecionado();

            if (CondutorSelecionado == null)
            {
                MessageBox.Show("Selecione um Condutor primeiro",
                "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir um Condutor?",
                "Exclusão de Condutor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioCondutor.Excluir(CondutorSelecionado);
                CarregarCondutores();
            }
        }


        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            throw new NotImplementedException();
        }

        private Condutor ObtemCondutorSelecionado()
        {
            var numero = tabelaCondutor.ObtemNumeroCondutorSelecionado();

            return repositorioCondutor.SelecionarPorId(numero);
        }


        private void CarregarCondutores()
        {

            List<Condutor> Condutores = repositorioCondutor.SelecionarTodos();

            tabelaCondutor.AtualizarRegistros(Condutores);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {Condutores.Count} Condutores(s)");
        }
    }
}
