using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Infra.BancoDados.tests.ModuloPlanoDeCobranca
{
    [TestClass]
    public class RepositorioPlanoDeCobrancaEmBancoDeDadosTest
    {
        PlanoDeCobranca planoDeCobranca;
        PlanoDeCobranca planoDeCobranca1;
        PlanoDeCobranca planoDeCobranca2;
        GrupoDeVeiculo grupo;

        private RepositorioPlanoDeCobrancaEmBancoDeDados repositorioPlanoDeCobranca;
        private RepositorioGrupoDeVeiculoOrm repositorioGrupoDeVeiculo;
        public RepositorioPlanoDeCobrancaEmBancoDeDadosTest()
        {
            DB.executarSql("DELETE FROM TBPlanoDeCobranca;");

            grupo = new GrupoDeVeiculo("Usados");

            PlanoDiario diario = new PlanoDiario(149.34m, 3.44m);
            PlanoLivre livre = new PlanoLivre(235.99m);
            PlanoControlado controlado = new PlanoControlado(115.99m, 3.90m, 100);

            planoDeCobranca = new PlanoDeCobranca("plano1", grupo, livre, diario, controlado);

            planoDeCobranca1 = new PlanoDeCobranca("plano2", grupo, livre, diario, controlado);

            planoDeCobranca2 = new PlanoDeCobranca("plano3", grupo, livre, diario, controlado);

            repositorioPlanoDeCobranca = new RepositorioPlanoDeCobrancaEmBancoDeDados();
            repositorioGrupoDeVeiculo = new RepositorioGrupoDeVeiculoOrm();
        }

        [TestMethod]
        public void Deve_inserir_PlanoDeCobranca()
        {
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
            repositorioGrupoDeVeiculo.Inserir(grupo);

            var PlanoDeCobrancaEncontrado = repositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);

            Assert.IsNotNull(PlanoDeCobrancaEncontrado);

            Assert.AreEqual(planoDeCobranca.Equals(PlanoDeCobrancaEncontrado), true);
        }

        [TestMethod]
        public void Deve_Editar_PlanoDeCobranca()
        {
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
            repositorioGrupoDeVeiculo.Inserir(grupo);

            planoDeCobranca.Nome = "seu zé";

            repositorioPlanoDeCobranca.Editar(planoDeCobranca);

            var PlanoDeCobrancaEditado = repositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);


            Assert.IsNotNull(PlanoDeCobrancaEditado);

            Assert.AreEqual(planoDeCobranca, PlanoDeCobrancaEditado);
        }

        [TestMethod]
        public void Deve_Excluir_PlanoDeCobranca()
        {

            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
            repositorioGrupoDeVeiculo.Inserir(grupo);

            repositorioPlanoDeCobranca.Excluir(planoDeCobranca);

            var PlanoDeCobrancaEncontrado = repositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);

            Assert.IsNull(PlanoDeCobrancaEncontrado);

        }

        [TestMethod]
        public void Deve_Selecionar_Um_PlanoDeCobranca()
        {
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
            repositorioGrupoDeVeiculo.Inserir(grupo);

            var PlanoDeCobrancaEncontrado = repositorioPlanoDeCobranca.SelecionarPorId(planoDeCobranca.Id);

            Assert.IsNotNull(PlanoDeCobrancaEncontrado);

            Assert.AreEqual(planoDeCobranca, PlanoDeCobrancaEncontrado);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_PlanoDeCobranca()
        {
            int quantidade = 3;

            repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca1);
            repositorioPlanoDeCobranca.Inserir(planoDeCobranca2);

            repositorioGrupoDeVeiculo.Inserir(grupo);

            var PlanoDeCobrancas = repositorioPlanoDeCobranca.SelecionarTodos();

            Assert.AreEqual(quantidade, PlanoDeCobrancas.Count);
            Assert.AreEqual(PlanoDeCobranca.Equals(PlanoDeCobrancas[0], planoDeCobranca), true);
            Assert.AreEqual(PlanoDeCobranca.Equals(PlanoDeCobrancas[1], planoDeCobranca1), true);
            Assert.AreEqual(PlanoDeCobranca.Equals(PlanoDeCobrancas[2], planoDeCobranca2), true);
        }

    }
}
