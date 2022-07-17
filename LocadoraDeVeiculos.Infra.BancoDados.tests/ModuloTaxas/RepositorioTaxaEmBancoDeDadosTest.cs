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
        Taxa taxa1;
        Taxa taxa2;

        RepositorioTaxaEmBancoDeDados repositorioTaxa;

        public RepositorioTaxaEmBancoDeDadosTest()
        {
            DB.executarSql("DELETE FROM TBTAXA;");

            taxa = new Taxa(0.3, "imposto", TipoCalculo.Diario);
            taxa1 = new Taxa(0.25, "ipva", TipoCalculo.Fixo);
            taxa2 = new Taxa(0.05, "taxa de limpeza", TipoCalculo.Diario);
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

            repositorioTaxa.Inserir(taxa);
            repositorioTaxa.Inserir(taxa1);
            repositorioTaxa.Inserir(taxa2);

            var taxas = repositorioTaxa.SelecionarTodos();

            Assert.AreEqual(quantidade, taxas.Count);
            Assert.AreEqual(Taxa.Equals(taxas[2], taxa), true);
            Assert.AreEqual(Taxa.Equals(taxas[1], taxa1), true);
            Assert.AreEqual(Taxa.Equals(taxas[0], taxa2), true);
        }
    }
}
