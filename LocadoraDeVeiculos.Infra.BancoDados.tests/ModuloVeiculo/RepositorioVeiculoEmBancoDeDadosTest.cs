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
        Veiculo veiculo;
        Veiculo veiculo1;
        Veiculo veiculo2;
        GrupoDeVeiculo grupoDeVeiculo;

        private RepositorioVeiculoEmBancoDeDados repositorioVeiculo;
        private RepositorioGrupoDeVeiculoEmBancoDeDados repositorioGrupo;

        public RepositorioVeiculoEmBancoDeDadosTest()
        {

            DB.executarSql("DELETE FROM TBVEICULO;");
            DB.executarSql("DELETE FROM TBGRUPOVEICULO;");


            grupoDeVeiculo = new GrupoDeVeiculo("Economico");
            veiculo = new Veiculo("Ford", "Ka", "Vermelho", "2020", "Gasolina", "BRA2E19", 100000, 50, new byte[] { })
            {
                GrupoDeVeiculo = grupoDeVeiculo,
            };

            veiculo1 = new Veiculo("Fiat", "Uno", "Bordo", "1994", "Gasolina", "BRA4E19", 250000, 50, new byte[] { })
            {
                GrupoDeVeiculo = grupoDeVeiculo,
            };

            veiculo2 = new Veiculo("Nissan", "Silvia", "Cinza", "1999", "Gasolina", "JPA2E19", 150000, 50, new byte[] { })
            {
                GrupoDeVeiculo = grupoDeVeiculo,
            };


            repositorioVeiculo = new RepositorioVeiculoEmBancoDeDados();
            repositorioGrupo = new RepositorioGrupoDeVeiculoEmBancoDeDados();

        }

        [TestMethod]
        public void Deve_inserir_veiculo()
        {
            repositorioGrupo.Inserir(grupoDeVeiculo);
            repositorioVeiculo.Inserir(veiculo);


            var VeiculoEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            Assert.IsNotNull(VeiculoEncontrado);
            Assert.AreEqual(veiculo, VeiculoEncontrado);
        }

        [TestMethod]
        public void Deve_Editar_veiculo()
        {
            repositorioGrupo.Inserir(grupoDeVeiculo);
            repositorioVeiculo.Inserir(veiculo);

            veiculo.Marca = "Fiat";

            repositorioVeiculo.Editar(veiculo);

            var veiculoEditado = repositorioVeiculo.SelecionarPorId(veiculo.Id);


            Assert.IsNotNull(veiculoEditado);

            Assert.AreEqual(veiculo, veiculoEditado);
        }

        [TestMethod]
        public void Deve_Excluir_Condutor()
        {
            repositorioGrupo.Inserir(grupoDeVeiculo);
            repositorioVeiculo.Inserir(veiculo);

            repositorioVeiculo.Excluir(veiculo);

            var CondutorEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            Assert.IsNull(CondutorEncontrado);

        }

        [TestMethod]
        public void Deve_Selecionar_Um_Condutor()
        {
            repositorioGrupo.Inserir(grupoDeVeiculo);
            repositorioVeiculo.Inserir(veiculo);

            var CondutorEncontrado = repositorioVeiculo.SelecionarPorId(veiculo.Id);

            Assert.IsNotNull(CondutorEncontrado);

            Assert.AreEqual(veiculo, CondutorEncontrado);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Os_Veiculos()
        {
            int quantidade = 3;

            repositorioGrupo.Inserir(grupoDeVeiculo);
            repositorioVeiculo.Inserir(veiculo);
            repositorioVeiculo.Inserir(veiculo1);
            repositorioVeiculo.Inserir(veiculo2);



            var veiculos = repositorioVeiculo.SelecionarTodos();

            Assert.AreEqual(quantidade, veiculos.Count);

        }

    }
}
