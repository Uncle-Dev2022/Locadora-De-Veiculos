using LocadoraDeVeiculos.Dominio.ModuloFuncionário;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloFuncionário;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace LocadoraDeVeiculos.Infra.BancoDados.tests.ModuloFuncionário
{
    [TestClass]
    public class RepositorioFuncionarioEmBancoDeDadosTeste
    {
        Funcionario funcionario;

        RepositorioFuncionarioEmBancoDeDados repositorioFuncionario;

        public RepositorioFuncionarioEmBancoDeDadosTeste()
        {
            DB.executarSql("DELETE FROM TBFUNCIONARIO; DBCC CHECKIDENT (TBFUNCIONARIO, RESEED, 0)");

            funcionario = new Funcionario("Funcionario", 1000 , DateTime.Parse("26/06/2022") , "Senha1", "Login1", true );

            repositorioFuncionario = new RepositorioFuncionarioEmBancoDeDados();

        }

        [TestMethod]
        public void Deve_Inserir_Funcionario()
        {
            //action
            repositorioFuncionario.Inserir(funcionario);

            //assert
            var funcionarioEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_Editar_Funcionario()
        {
            repositorioFuncionario.Inserir(funcionario);

            funcionario.Nome = "Tio Home";
            funcionario.Salario = 500;
            funcionario.DataAdmissao = DateTime.Parse("02/06/2022");
            funcionario.Senha = "TIOHOME";
            funcionario.Login = "TioHome";
            funcionario.Gerente = true;

            repositorioFuncionario.Editar(funcionario);

            var funcionarioEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);


            Assert.IsNotNull(funcionarioEncontrado);

            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_Excluir_Funcionario()
        {

            repositorioFuncionario.Inserir(funcionario);

            repositorioFuncionario.Excluir(funcionario);

            var FuncionarioEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            Assert.IsNull(FuncionarioEncontrado);

        }

        [TestMethod]
        public void Deve_Selecionar_Um_Funcionario()
        {
            repositorioFuncionario.Inserir(funcionario);

            var FuncionarioEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

            Assert.IsNotNull(FuncionarioEncontrado);

            Assert.AreEqual(funcionario, FuncionarioEncontrado);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Funcionario()
        {
            int quantidade = 3;

            for (int i = 0; i < quantidade; i++)
                repositorioFuncionario.Inserir(this.funcionario);

            var funcionario = repositorioFuncionario.SelecionarTodos();

            Assert.AreEqual(quantidade, funcionario.Count);

        }

    }
}
