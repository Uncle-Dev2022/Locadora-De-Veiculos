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
        Cliente clientePessoaFisica1;
        Cliente clientePessoaFisica2;

        Cliente ClientePessoaJuridica;

        private RepositorioClienteEmBancoDeDados repositorioCliente;
        public RepositorioClienteEmBancoDeDadosTest()
        {
            DB.executarSql("DELETE FROM TBCONDUTOR;");
            DB.executarSql("DELETE FROM TBCLIENTE;");

            clientePessoaFisica = new Cliente("Thiago", "rua", "Thiago@gmail.com", "(49) 98547-4512", true, "245.457.458-12", "012457896");

            clientePessoaFisica1 = new Cliente("Alvaro", "rua", "Thiago@gmail.com", "(49) 98747-4512", true, "245.657.458-12", "012757896");

            clientePessoaFisica2 = new Cliente("Thiago", "rua", "Thiago@gmail.com", "(49) 98547-4512", true, "245.487.458-12", "012457696");

            ClientePessoaJuridica = new Cliente("Empresa", "rua", "empresa@gmail.com", "(49) 98547-4215", false, "25.427.475/0001-00", null);

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

        [TestMethod]
        public void Deve_inserir_Cliente_PessoaJuridica()
        {
            repositorioCliente.Inserir(ClientePessoaJuridica);

            var ClienteEncontrado = repositorioCliente.SelecionarPorId(ClientePessoaJuridica.Id);

            Assert.IsNotNull(ClienteEncontrado);
            Assert.AreEqual(ClientePessoaJuridica, ClienteEncontrado);
        }

        [TestMethod]
        public void Deve_Editar_Cliente_PessoaFisica()
        {
            repositorioCliente.Inserir(clientePessoaFisica);

            clientePessoaFisica.Nome = "seu zé";

            repositorioCliente.Editar(clientePessoaFisica);

            var ClienteEditado = repositorioCliente.SelecionarPorId(clientePessoaFisica.Id);


            Assert.IsNotNull(ClienteEditado);

            Assert.AreEqual(clientePessoaFisica, ClienteEditado);
        }

        [TestMethod]
        public void Deve_Excluir_Cliente_PessoaFisica()
        {

            repositorioCliente.Inserir(clientePessoaFisica);

            repositorioCliente.Excluir(clientePessoaFisica);

            var ClienteEncontrado = repositorioCliente.SelecionarPorId(clientePessoaFisica.Id);

            Assert.IsNull(ClienteEncontrado);

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

            repositorioCliente.Inserir(clientePessoaFisica);
            repositorioCliente.Inserir(clientePessoaFisica1);
            repositorioCliente.Inserir(clientePessoaFisica2);


            var Clientes = repositorioCliente.SelecionarTodos();

            Assert.AreEqual(quantidade, Clientes.Count);

        }



    }
}

