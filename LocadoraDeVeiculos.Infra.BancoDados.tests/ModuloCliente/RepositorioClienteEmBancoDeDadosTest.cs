using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.tests.ModuloCliente
{
   

    [TestClass]
    public class RepositorioClienteEmBancoDeDadosTest
    {
        Cliente clientePessoaFisica;
        Cliente ClientePessoaJuridica;

        private RepositorioClienteEmBancoDeDados repositorioCliente;
        public RepositorioClienteEmBancoDeDadosTest()
        {
            DB.executarSql("DELETE FROM TBCLIENTE; DBCC CHECKIDENT (TBCLIENTE, RESEED, 0)");

            clientePessoaFisica = new Cliente("Thiaguera","Rua Rua","Email@email.com","34521867",true,"12457865920","014257846521");

            ClientePessoaJuridica = new Cliente("auto.cia", "rua Alberto", "auto@email.com", "34521548", false, "021475896000112",null);

            repositorioCliente = new RepositorioClienteEmBancoDeDados();
        }
        
        [TestMethod]
        public void Deve_inserir_Cliente_PessoaFisica()
        {
            repositorioCliente.Inserir(clientePessoaFisica);

            var ClienteEncontrado = repositorioCliente.SelecionarPorId(clientePessoaFisica.Id);

            Assert.IsNotNull(ClienteEncontrado);
            Assert.AreEqual(clientePessoaFisica, ClienteEncontrado);
        }

        //[TestMethod]
        //public void Deve_inserir_Cliente_PessoaJuridica()
        //{
        //    repositorioCliente.Inserir(ClientePessoaJuridica);

        //    var ClienteEncontrado = repositorioCliente.SelecionarPorId(ClientePessoaJuridica.Id);

        //    Assert.IsNotNull(ClienteEncontrado);
        //    Assert.AreEqual(ClientePessoaJuridica, ClienteEncontrado);
        //}

        [TestMethod]
        public void Deve_Editar_Cliente_PessoaFisica()
        {
            repositorioCliente.Inserir(clientePessoaFisica);

            clientePessoaFisica.Nome = "Tio Home";

            repositorioCliente.Editar(clientePessoaFisica);

            var GrupoDeVeiculoEditado = repositorioCliente.SelecionarPorId(clientePessoaFisica.Id);


            Assert.IsNotNull(GrupoDeVeiculoEditado);

            Assert.AreEqual(clientePessoaFisica, GrupoDeVeiculoEditado);
        }

        [TestMethod]
        public void Deve_Excluir_Cliente_PessoaFisica()
        {

            repositorioCliente.Inserir(clientePessoaFisica);

            repositorioCliente.Excluir(clientePessoaFisica);

            var GrupoDeVeiculoEncontrado = repositorioCliente.SelecionarPorId(clientePessoaFisica.Id);

            Assert.IsNull(GrupoDeVeiculoEncontrado);

        }

        [TestMethod]
        public void Deve_Selecionar_Um_Cliente_PessoaFisica()
        {
            repositorioCliente.Inserir(clientePessoaFisica);

            var ClienteEncontrado = repositorioCliente.SelecionarPorId(clientePessoaFisica.Id);

            Assert.IsNotNull(ClienteEncontrado);

            Assert.AreEqual(clientePessoaFisica, ClienteEncontrado);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Cliente_PessoaFisica()
        {
            int quantidade = 3;

            for (int i = 0; i < quantidade; i++)
                repositorioCliente.Inserir(clientePessoaFisica);

            var Clientes = repositorioCliente.SelecionarTodos();

            Assert.AreEqual(quantidade, Clientes.Count);

        }



    }
}

