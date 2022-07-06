﻿using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
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
            DB.executarSql("DELETE FROM TBVEICULO; DBCC CHECKIDENT (TBVEICULO, RESEED, 0)");

            repositorioVeiculo = new RepositorioVeiculoEmBancoDeDados();
            repositorioGrupo = new RepositorioGrupoDeVeiculoEmBancoDeDados();

        }

        [TestMethod]
        public void Deve_inserir_veiculo()
        {
            //arrange
            var veiculo = NovoVeiculo1();
            

            //action
            repositorioVeiculo.Inserir(veiculo);

            //assert
            var resultado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            Assert.IsNotNull(resultado);
        }


        private Veiculo NovoVeiculo1()
        {
            var veiculo = new Veiculo("Economico","Ford", "Ka","Vermelho", "2020", "Gasolina", "BRA2E19", 100000 , 50 , new byte[] { });

            return veiculo;
        }
    }
}
