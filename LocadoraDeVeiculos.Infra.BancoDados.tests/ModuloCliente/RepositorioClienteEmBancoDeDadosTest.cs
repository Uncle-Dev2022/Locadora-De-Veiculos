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
        private PessoaFisica pessoaFisica;
        private PessoaJuridica pessoaJuridica;
        private Cliente clienteFisico;
        private Cliente clienteJuridico;
        private RepositorioClienteEmBancoDeDados repositorioCliente;
        public RepositorioClienteEmBancoDeDadosTest()
        {
            DB.executarSql("DELETE FROM TBCLIENTE; DBCC CHECKIDENT (TBCLIENTE, RESEED, 0)");

            pessoaFisica = new PessoaFisica("Thiago","rua","Email@email.com","32254784","04125735409","324578698742");
            pessoaJuridica = new PessoaJuridica();
            clienteFisico = pessoaFisica;
            clienteJuridico = pessoaJuridica;
            repositorioCliente = new RepositorioClienteEmBancoDeDados();
        }
        
        [TestMethod]
        public void Deve_inserir_Cliente_PessoaFisica()
        {
            repositorioCliente.Inserir(pessoaFisica);

            var PessoaFissicaEncontrada = repositorioCliente.SelecionarPorId(pessoaFisica.Id);

            Assert.IsNotNull(PessoaFissicaEncontrada);
            Assert.AreEqual(pessoaFisica, PessoaFissicaEncontrada);
        }

    }
}
