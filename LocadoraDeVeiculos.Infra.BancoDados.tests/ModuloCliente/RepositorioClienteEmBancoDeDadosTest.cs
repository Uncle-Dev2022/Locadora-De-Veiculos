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
        Cliente cliente;

        private RepositorioClienteEmBancoDeDados repositorioCliente;
        public RepositorioClienteEmBancoDeDadosTest()
        {
            DB.executarSql("DELETE FROM TBCLIENTE; DBCC CHECKIDENT (TBCLIENTE, RESEED, 0)");

            cliente = new Cliente("Thiaguera","Rua Rua","Email@email.com","34521867",true,"12457865920","014257846521");

            repositorioCliente = new RepositorioClienteEmBancoDeDados();
        }
        
        [TestMethod]
        public void Deve_inserir_Cliente_PessoaFisica()
        {
            repositorioCliente.Inserir(cliente);

            var ClienteEncontrado = repositorioCliente.SelecionarPorId(cliente.Id);

            Assert.IsNotNull(ClienteEncontrado);
            Assert.AreEqual(cliente, ClienteEncontrado);
        }

    }
}
