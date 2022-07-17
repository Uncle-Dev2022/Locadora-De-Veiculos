using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LocadoraDeVeiculos.Dominio.Tests.ModuloGrupoDeVeiculos
{
    [TestClass]
    public class ValidadorGrupoDeVeiculoTeste 
    {
        [TestMethod]
        public void Nome_nao_Pode_Ser_Nulo()
        {
            Funcionario gv = new(null);

            ValidadorGrupoDeVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(gv);

            //assert
            Assert.AreEqual("Nome não pode ser nulo", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nome_nao_Pode_Ser_Vazio()
        {
            Funcionario gv = new("");

            ValidadorGrupoDeVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(gv);

            //assert
            Assert.AreEqual("Nome não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nome_Deve_Ter_Minimo_Dois_Caracteres()
        {
            Funcionario gv = new("N");

            ValidadorGrupoDeVeiculo valfor = new();

            //action
            ValidationResult resultado = valfor.Validate(gv);

            //assert
            Assert.AreEqual("Nome deve ter no mínimo 2 caracteres", resultado.Errors[0].ErrorMessage);
        }

    }
}
