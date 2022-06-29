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

        RepositorioGrupoDeVeiculoEmBancoDeDados repositorioGrupoDeVeiculo;

        public RepositorioGrupoDeVeiculoBancoDeDadosTeste()
        {
            DB.executarSql("DELETE FROM TBGRUPOVEICULO; DBCC CHECKIDENT (TBGRUPOVEICULO, RESEED, 0)");

            grupoVeiculo = new GrupoDeVeiculo("GrupoDeVeiculo");

            repositorioGrupoDeVeiculo = new RepositorioGrupoDeVeiculoEmBancoDeDados();

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

            for (int i = 0; i < quantidade; i++)
                repositorioGrupoDeVeiculo.Inserir(grupoVeiculo);

            var grupoVeiculos = repositorioGrupoDeVeiculo.SelecionarTodos();

            Assert.AreEqual(quantidade, grupoVeiculos.Count);

        }



    }
}
