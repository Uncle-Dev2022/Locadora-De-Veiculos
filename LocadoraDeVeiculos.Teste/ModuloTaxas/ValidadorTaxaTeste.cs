using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloTaxas
{
    [TestClass]
    public class ValidadorTaxaTeste
    {
        [TestMethod]
        public void Descricao_nao_Pode_Ser_Nula()
        { 
            Taxa taxa = new(0.3 , "", TipoCalculo.Diario);

            ValidadorTaxa validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(taxa);

            //assert
            Assert.AreEqual("A Descrição não pode ser vazia", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Descricao_Deve_Ter_Minimo_Dois_Caracteres()
        {
            Taxa taxa = new(0.3, "i", TipoCalculo.Fixo);

            ValidadorTaxa valfor = new();

            //action
            ValidationResult resultado = valfor.Validate(taxa);

            //assert
            Assert.AreEqual("A Descrição não pode ser vazia ou possuir menos que 2 caracteres", resultado.Errors[0].ErrorMessage);
        }
        [TestMethod]
        public void Descricao_Nao_Pode_Conter_Numeros_Ou_Simbolos_Especiais()
        {
            Taxa taxa = new(0.3, "imp#osto", TipoCalculo.Diario);

            ValidadorTaxa valfor = new();

            //action
            ValidationResult resultado = valfor.Validate(taxa);

            //assert
            Assert.AreEqual("A Descrição não pode conter números ou símbolos especiais", resultado.Errors[0].ErrorMessage);
        }
        public void Valor_Nao_Pode_Ser_Nulo()
        {
            Taxa taxa = new(default, "imposto", TipoCalculo.Fixo);

            ValidadorTaxa valfor = new();

            //action
            ValidationResult resultado = valfor.Validate(taxa);

            //assert
            Assert.AreEqual("O valor não pode ser nulo", resultado.Errors[0].ErrorMessage);

        }
    }
}
