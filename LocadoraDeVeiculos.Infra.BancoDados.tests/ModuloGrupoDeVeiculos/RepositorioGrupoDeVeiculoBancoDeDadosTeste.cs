using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Infra.BancoDados.tests.ModuloGrupoDeVeiculos
{
    [TestClass]
    public class RepositorioGrupoDeVeiculoBancoDeDadosTeste
    {
        GrupoDeVeiculo grupoVeiculo;
        GrupoDeVeiculo grupoVeiculo1;
        GrupoDeVeiculo grupoVeiculo2;

        RepositorioGrupoDeVeiculoOrm repositorioGrupoDeVeiculo;

        public RepositorioGrupoDeVeiculoBancoDeDadosTeste()
        {
            DB.executarSql("DELETE FROM TBGRUPOVEICULO;");

            grupoVeiculo = new GrupoDeVeiculo("GrupoDeVeiculo");
            grupoVeiculo1 = new GrupoDeVeiculo("GrupoDeVeiculoUm");
            grupoVeiculo2 = new GrupoDeVeiculo("GrupoDeVeiculoDois");

            repositorioGrupoDeVeiculo = new RepositorioGrupoDeVeiculoOrm();

        }

        [TestMethod]
        public void Deve_Inserir_GrupoDeVeiculo()
        {
            //action
            repositorioGrupoDeVeiculo.Inserir(grupoVeiculo);

            //assert
            var GrupoVeiculoEncontrado = repositorioGrupoDeVeiculo.SelecionarPorId(grupoVeiculo.Id);

            Assert.IsNotNull(GrupoVeiculoEncontrado);
            Assert.AreEqual(grupoVeiculo, GrupoVeiculoEncontrado);
        }

        [TestMethod]
        public void Deve_Editar_GrupoDeVeiculo()
        {
            repositorioGrupoDeVeiculo.Inserir(grupoVeiculo);

            grupoVeiculo.Nome = "Tio Home";

            repositorioGrupoDeVeiculo.Editar(grupoVeiculo);

            var GrupoDeVeiculoEditado = repositorioGrupoDeVeiculo.SelecionarPorId(grupoVeiculo.Id);


            Assert.IsNotNull(GrupoDeVeiculoEditado);

            Assert.AreEqual(grupoVeiculo, GrupoDeVeiculoEditado);
        }

        [TestMethod]
        public void Deve_Excluir_GrupoDeVeiculo()
        {

            repositorioGrupoDeVeiculo.Inserir(grupoVeiculo);

            repositorioGrupoDeVeiculo.Excluir(grupoVeiculo);

            var GrupoDeVeiculoEncontrado = repositorioGrupoDeVeiculo.SelecionarPorId(grupoVeiculo.Id);

            Assert.IsNull(GrupoDeVeiculoEncontrado);

        }

        [TestMethod]
        public void Deve_Selecionar_Um_GrupoDeVeiculo()
        {
            repositorioGrupoDeVeiculo.Inserir(grupoVeiculo);

            var GrupoDeVeiculoEncontrado = repositorioGrupoDeVeiculo.SelecionarPorId(grupoVeiculo.Id);

            Assert.IsNotNull(GrupoDeVeiculoEncontrado);

            Assert.AreEqual(grupoVeiculo, GrupoDeVeiculoEncontrado);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_GrupoDeVeiculo()
        {
            int quantidade = 3;

            repositorioGrupoDeVeiculo.Inserir(grupoVeiculo);
            repositorioGrupoDeVeiculo.Inserir(grupoVeiculo1);
            repositorioGrupoDeVeiculo.Inserir(grupoVeiculo2);

            var grupoVeiculos = repositorioGrupoDeVeiculo.SelecionarTodos();

            Assert.AreEqual(quantidade, grupoVeiculos.Count);

        }



    }
}
