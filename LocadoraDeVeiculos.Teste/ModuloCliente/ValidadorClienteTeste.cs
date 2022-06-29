using LocadoraDeVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloCliente
{
    [TestClass]
    public class ValidadorClienteTeste
    {
        //Cliente ClienteFisico = new Cliente("Thiago", "rua", "Thiago@gmail.com", "(49) 98547-4512", true, "245.457.458-12", "012457896");
        //Cliente ClienteJuridico = new Cliente("Empresa", "rua", "empresa@gmail.com", "(49) 98547-4215", false, "25.427.475/0001-00", null);

        [TestMethod]
        public void Nome_Do_Cliente_Obrigatorio()
        {
            Cliente c1 = new Cliente("","rua","Thiago@gmail.com","(49) 98547-4512",true,"245.457.458-12","012457896");
            Cliente c2=new Cliente(null, "rua", "Thiago@gmail.com", "(49) 98547-4512", true, "245.457.458-12", "012457896");

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.IsNotNull("'Nome' NÃO pode estar vazio", resultado1.Errors[0].ErrorMessage);
            Assert.IsNotNull("'Nome' NÃO pode estar vazio", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nome_Do_Cliente_Deve_Ter_No_Minimo_Quatro_Caracteres()
        {
            Cliente c1 = new Cliente("ABC", "rua", "Thiago@gmail.com", "(49) 98547-4512", true, "245.457.458-12", "012457896");
            Cliente c2 = new Cliente("ab", "rua", "Thiago@gmail.com", "(49) 98547-4512", true, "245.457.458-12", "012457896");

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.IsNotNull("O 'Nome' deve ter no minimo 4 caracteres", resultado1.Errors[0].ErrorMessage);
            Assert.IsNotNull("O 'Nome' deve ter no minimo 4 caracteres", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nome_Do_Cliente_Sem_Caractere_Especial()
        {
            Cliente c1 = new Cliente("João", "rua", "Thiago@gmail.com", "(49) 98547-4512", true, "245.457.458-12", "012457896");
            Cliente c2 = new Cliente("carla1", "rua", "Thiago@gmail.com", "(49) 98547-4512", true, "245.457.458-12", "012457896");

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.IsNotNull("Caracteres especiais não são permitidos no campo 'Nome'", resultado1.Errors[0].ErrorMessage);
            Assert.IsNotNull("Caracteres especiais não são permitidos no campo 'Nome'", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Telefone_Do_cliente_E_Obrigatorio()
        {
            Cliente c1 = new Cliente("Thiago", "rua", "Thiago@gmail.com", "", true, "245.457.458-12", "012457896");
            Cliente c2 = new Cliente("ab", "rua", "Thiago@gmail.com", null, true, "245.457.458-12", "012457896");

            var validador = new ValidadorCliente();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.IsNotNull("O 'Nome' deve ter no minimo 4 caracteres", resultado1.Errors[0].ErrorMessage);
            Assert.IsNotNull("O 'Nome' deve ter no minimo 4 caracteres", resultado2.Errors[0].ErrorMessage);
        }
    }
}
