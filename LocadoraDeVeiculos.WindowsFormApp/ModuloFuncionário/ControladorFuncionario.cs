using LocadoraDeVeiculos.Dominio.ModuloFuncionário;
using LocadoraDeVeiculos.Infra.ModuloFuncionário;
using LocadoraDeVeiculos.WindowsFormApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp.ModuloFuncionário
{
    public class ControladorFuncionario : ControladorBase
    {

        private readonly RepositorioFuncionarioEmBancoDeDados repositorioFuncionario;
        private TabelaFuncionarioControl tabelaFuncionario;

        public ControladorFuncionario(RepositorioFuncionarioEmBancoDeDados repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public override void Inserir()
        {
            TelaCadastroFuncionarioForm tela = new TelaCadastroFuncionarioForm();
            tela._funcionario = new Funcionario();

            

            tela.GravarRegistro = repositorioFuncionario.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarFuncionario();
            }
        }

        public override void Editar()
        {
            Funcionario FuncionarioSelecionado = ObtemFuncionarioSelecionado();

            if (FuncionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionario primeiro",
                "Edição de funcionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroFuncionarioForm tela = new TelaCadastroFuncionarioForm();

            tela._funcionario = FuncionarioSelecionado;

            tela.GravarRegistro = repositorioFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarFuncionario();
            }
        }

        public override void Excluir()
        {
            Funcionario FuncionarioSelecionado = ObtemFuncionarioSelecionado();

            if (FuncionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionario primeiro",
                "Exclusão de funcionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir um funcionario?",
                "Exclusão de funcionario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioFuncionario.Excluir(FuncionarioSelecionado);
                CarregarFuncionario();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaFuncionario == null)
                tabelaFuncionario = new TabelaFuncionarioControl();

            CarregarFuncionario();

            return tabelaFuncionario;
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxFuncionario();
        }

        private Funcionario ObtemFuncionarioSelecionado()
        {
            var numero = tabelaFuncionario.ObtemNumeroFuncionarioSelecionado();

            return repositorioFuncionario.SelecionarPorId(numero);
        }

        private void CarregarFuncionario()
        {

            List<Funcionario> funcionario = repositorioFuncionario.SelecionarTodos();

            tabelaFuncionario.AtualizarRegistros(funcionario);

            if(funcionario.Count > 1)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {funcionario.Count} Funcionario(s)");
            }
            else
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {funcionario.Count} Funcionario");
        }


    }
}
