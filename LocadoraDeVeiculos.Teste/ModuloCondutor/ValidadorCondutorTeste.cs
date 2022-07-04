using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloCondutor
{
    [TestClass]
    public class ValidadorCondutorTeste
    {
        //Condutor c1 = new Condutor("thiago","ali","456.210.857-15","45123678940","thiago@gmail.com");
        //Condutor c2 = new Condutor("Matilda", "aqui", "123.0245.0123-05", "12345678910", "matilda@hotmail.com");

        [TestMethod]
        public void Nome_Condutor_Obrigatorio()
        {
            Condutor c1 = new Condutor("", "ali", "456.210.857-15", "45123678940", "thiago@gmail.com");
            Condutor c2 = new Condutor(null, "aqui", "123.0245.0123-05", "12345678910", "matilda@hotmail.com");

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.IsNotNull("'Nome' NÃO pode estar vazio", resultado1.Errors[0].ErrorMessage);
            Assert.IsNotNull("'Nome' NÃO pode estar vazio", resultado2.Errors[0].ErrorMessage);
        }
    }
}
