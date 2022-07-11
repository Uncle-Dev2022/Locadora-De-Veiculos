using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDados.tests.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorEmBancoDeDadosTest
    {
        Condutor condutor;
        Cliente cliente;
        
        private RepositorioCondutorEmBancoDeDados repositorioCondutor;
        private RepositorioClienteEmBancoDeDados repositorioCliente;

        public RepositorioCondutorEmBancoDeDadosTest()
        {
            DB.executarSql("DELETE FROM TBCONDUTOR; DBCC CHECKIDENT (TBCONDUTOR, RESEED, 0)");
            DB.executarSql("DELETE FROM TBCLIENTE; DBCC CHECKIDENT (TBCLIENTE, RESEED, 0)");

            cliente = new Cliente("Thiago", "rua", "Thiago@gmail.com", "(49) 98547 - 4512", true, "245.457.458 - 12", "012457896");
            
            condutor = new Condutor("Thiago", "rua", "013.421.157-24", "123456789546", "thiago@gmail.com")
            {
               cliente = cliente,
            };

            repositorioCliente = new RepositorioClienteEmBancoDeDados();
            repositorioCondutor = new RepositorioCondutorEmBancoDeDados();
        }

        [TestMethod]
        public void Deve_inserir_Condutor()
        {
            repositorioCliente.Inserir(cliente);
            repositorioCondutor.Inserir(condutor);

            var CondutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(CondutorEncontrado);
            Assert.AreEqual(condutor, CondutorEncontrado);
        }

        [TestMethod]
        public void Deve_Editar_Condutor()
        {
            repositorioCliente.Inserir(cliente);
            repositorioCondutor.Inserir(condutor);

            condutor.Nome = "Roanaldo O Fenomeno";

            repositorioCondutor.Editar(condutor);

            var CondutorEditado = repositorioCondutor.SelecionarPorId(condutor.Id);


            Assert.IsNotNull(CondutorEditado);

            Assert.AreEqual(condutor, CondutorEditado);
        }

        [TestMethod]
        public void Deve_Excluir_Condutor()
        {
            repositorioCliente.Inserir(cliente);
            repositorioCondutor.Inserir(condutor);

            repositorioCondutor.Excluir(condutor);

            var CondutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNull(CondutorEncontrado);

        }

        [TestMethod]
        public void Deve_Selecionar_Um_Condutor()
        {
            repositorioCliente.Inserir(cliente);
            repositorioCondutor.Inserir(condutor);

            var CondutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            Assert.IsNotNull(CondutorEncontrado);

            Assert.AreEqual(condutor, CondutorEncontrado);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Os_Condutores()
        {
            int quantidade = 3;

            for (int i = 0; i < quantidade; i++)
            {
                repositorioCliente.Inserir(cliente);
                repositorioCondutor.Inserir(condutor);
            }
                

            var Condutores = repositorioCondutor.SelecionarTodos();

            Assert.AreEqual(quantidade, Condutores.Count);

        }
    }
}
