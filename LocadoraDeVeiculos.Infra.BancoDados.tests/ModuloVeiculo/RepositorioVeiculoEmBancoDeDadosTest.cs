using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.tests.ModuloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoEmBancoDeDadosTest
    {
        private RepositorioVeiculoEmBancoDeDados repositorioVeiculo;
        private RepositorioGrupoDeVeiculoEmBancoDeDados repositorioGrupo;

        public RepositorioVeiculoEmBancoDeDadosTest()
        {
            DB.executarSql("DELETE FROM TBVEICULO;");

            repositorioVeiculo = new RepositorioVeiculoEmBancoDeDados();
            repositorioGrupo = new RepositorioGrupoDeVeiculoEmBancoDeDados();

        }

        [TestMethod]
        public void Deve_inserir_veiculo()
        {
            //arrange
            var grupo = NovoGrupo1();
            var veiculo = NovoVeiculo1();
            repositorioGrupo.Inserir(grupo);

            //action
            repositorioVeiculo.Inserir(veiculo);

            //assert
            var resultado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(veiculo, resultado);
        }

        private GrupoDeVeiculo NovoGrupo1()
        {
            var grupoDeVeiculo = new GrupoDeVeiculo("Economico");
            return grupoDeVeiculo;
        }

        private Veiculo NovoVeiculo1()
        {
            var veiculo = new Veiculo("Ford", "Ka","Vermelho", "2020", "Gasolina", "BRA2E19", 100000 , 50 , new byte[] { });

            return veiculo;
        }
    }
}
