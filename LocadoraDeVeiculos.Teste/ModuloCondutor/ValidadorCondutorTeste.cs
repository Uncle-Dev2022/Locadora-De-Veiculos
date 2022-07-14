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

        [TestMethod]
        public void Nome_Condutor_Sem_Caracteres_Especiais_E_com_mais_de_3_caracteres()
        {
            Condutor c1 = new Condutor("abc", "ali", "456.210.857-15", "45123678940", "thiago@gmail.com");
            Condutor c2 = new Condutor("Rod!rigo", "aqui", "123.0245.0123-05", "12345678910", "matilda@hotmail.com");

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.IsNotNull("O 'Nome' deve ter no minimo 4 caracteres", resultado1.Errors[0].ErrorMessage);
            Assert.IsNotNull("Caracteres especiais não são permitidos no campo 'Nome'", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Endereco_Condutor_Obrigatorio()
        {
            Condutor c1 = new Condutor("thiago", "", "456.210.857-15", "45123678940", "thiago@gmail.com");
            Condutor c2 = new Condutor("Matilda", null, "123.0245.0123-05", "12345678910", "matilda@hotmail.com");
            
            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.IsNotNull("'Endereco' NÃO pode estar vazio", resultado1.Errors[0].ErrorMessage);
            Assert.IsNotNull("'Endereco' NÃO pode estar vazio", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Email_Condutor_Obrigatorio()
        {
            Condutor c1 = new Condutor("thiago", "ali", "456.210.857-15", "45123678940", "");
            Condutor c2 = new Condutor("Matilda", "aqui", "123.0245.0123-05", "12345678910", null);

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.IsNotNull("'Email' NÃO pode estar vazio", resultado1.Errors[0].ErrorMessage);
            Assert.IsNotNull("'Email' NÃO pode estar vazio", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Email_Condutor_Deve_Seguir_O_Padrao()
        {
            Condutor c1 = new Condutor("thiago", "ali", "456.210.857-15", "45123678940", "abc.com");
            Condutor c2 = new Condutor("Matilda", "aqui", "123.0245.0123-05", "12345678910", "abr@");

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.IsNotNull("'Email' Inválido,Tente Novamente", resultado1.Errors[0].ErrorMessage);
            Assert.IsNotNull("'Email' Inválido,Tente Novamente", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void CPF_Condutor_Obrigatorio()
        {
            Condutor c1 = new Condutor("thiago", "ali", "", "45123678940", "thiago@gmail.com");
            Condutor c2 = new Condutor("Matilda", "aqui", null, "12345678910", "matilda@hotmail.com");

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.IsNotNull("'CPF' NÃO pode estar vazio", resultado1.Errors[0].ErrorMessage);
            Assert.IsNotNull("'CPF' NÃO pode estar vazio", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void CPF_Condutor_Deve_Seguir_O_Padrao()
        {
            Condutor c1 = new Condutor("thiago", "ali", "456210.857-15", "45123678940", "thiago@gmail.com");
            Condutor c2 = new Condutor("Matilda", "aqui", "123.0245012305", "12345678910", "matilda@hotmail.com");

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.IsNotNull("'CPF' inválido, tente novamente", resultado1.Errors[0].ErrorMessage);
            Assert.IsNotNull("'CPF' inválido, tente novamente", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void CNH_Condutor_Obrigatorio()
        {
            Condutor c1 = new Condutor("thiago","ali","456.210.857-15","","thiago@gmail.com");
            Condutor c2 = new Condutor("Matilda", "aqui", "123.0245.0123-05", null, "matilda@hotmail.com");

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.IsNotNull("'CNH' NÃO pode estar vazio", resultado1.Errors[0].ErrorMessage);
            Assert.IsNotNull("'CNH' NÃO pode estar vazio", resultado2.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void CNH_Condutor_Deve_Seguir_O_Padrao()
        {
            Condutor c1 = new Condutor("thiago", "ali", "456210.857-15", "4512368940", "thiago@gmail.com");
            Condutor c2 = new Condutor("Matilda", "aqui", "123.0245012305", "abvr54gth68", "matilda@hotmail.com");

            var validador = new ValidadorCondutor();

            var resultado1 = validador.Validate(c1);
            var resultado2 = validador.Validate(c2);

            Assert.IsNotNull("'CNH' Inválida, tente novamente", resultado1.Errors[0].ErrorMessage);
            Assert.IsNotNull("'CNH' Inválida, tente novamente", resultado2.Errors[0].ErrorMessage);
        }
    }
}
