using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloTaxas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.tests.ModuloTaxas
{
    [TestClass]
    public class RepositorioTaxaEmBancoDeDadosTest
    {
        Taxa taxa;

        RepositorioTaxaEmBancoDeDados repositorioTaxa;

        public RepositorioTaxaEmBancoDeDadosTest()
        {
            DB.executarSql("DELETE FROM TBTAXA; DBCC CHECKIDENT (TBTAXA, RESEED, 0)");

            taxa = new Taxa(0.3, "imposto", TipoCalculo.Diario);

            repositorioTaxa = new RepositorioTaxaEmBancoDeDados();

        }

        [TestMethod]
        public void Deve_Inserir_Taxa()
        {
            //action
            repositorioTaxa.Inserir(taxa);

            //assert
            var taxaEncontrada = repositorioTaxa.SelecionarPorId(taxa.Id);

            Assert.IsNotNull(taxaEncontrada);
            Assert.AreEqual(taxa, taxaEncontrada);
        }

        [TestMethod]
        public void Deve_Editar_Taxa()
        {
            repositorioTaxa.Inserir(taxa);

            taxa.descricao = "Tio Home";

            repositorioTaxa.Editar(taxa);

            var taxaEditada = repositorioTaxa.SelecionarPorId(taxa.Id);


            Assert.IsNotNull(taxaEditada);

            Assert.AreEqual(taxa, taxaEditada);
        }

        [TestMethod]
        public void Deve_Excluir_Taxa()
        {

            repositorioTaxa.Inserir(taxa);

            repositorioTaxa.Excluir(taxa);

            var taxaEncontrada = repositorioTaxa.SelecionarPorId(taxa.Id);

            Assert.IsNull(taxaEncontrada);

        }

        [TestMethod]
        public void Deve_Selecionar_Uma_Taxa()
        {
            repositorioTaxa.Inserir(taxa);

            var taxaEncontrada = repositorioTaxa.SelecionarPorId(taxa.Id);

            Assert.IsNotNull(taxaEncontrada);

            Assert.AreEqual(taxa, taxaEncontrada);
        }

        [TestMethod]
        public void Deve_Selecionar_Todas_Taxas()
        {
            int quantidade = 3;

            for (int i = 0; i < quantidade; i++)
                repositorioTaxa.Inserir(this.taxa);

            var taxas = repositorioTaxa.SelecionarTodos();

            Assert.AreEqual(quantidade, taxas.Count);

        }
    }
}
