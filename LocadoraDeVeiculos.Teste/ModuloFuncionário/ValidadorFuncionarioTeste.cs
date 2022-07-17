using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionário;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloFuncionário
{

    [TestClass]
    public class ValidadorFuncionarioTeste
    {
        [TestMethod]
        public void Nome_nao_Pode_Ser_Nulo()
        {
            Funcionario funcionario = new(null, 1000, DateTime.Parse("26/06/2022"), "Senha1", "Login1", true);

            ValidadorFuncionario validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(funcionario);

            //assert
            Assert.AreEqual("Nome não pode ser nulo", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nome_nao_Pode_Ser_Vazio()
        {
            Funcionario funcionario = new("", 1000, DateTime.Parse("26/06/2022"), "Senha1", "Login1", true);

            ValidadorFuncionario validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(funcionario);

            //assert
            Assert.AreEqual("Nome não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Nome_Deve_Ter_Minimo_Dois_Caracteres()
        {
            Funcionario funcionario = new("F", 1000, DateTime.Parse("26/06/2022"), "Senha1", "Login1", true);

            ValidadorFuncionario validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(funcionario);

            //assert
            Assert.AreEqual("Nome deve ter no mínimo 2 caracteres", resultado.Errors[0].ErrorMessage);
        }



        [TestMethod]
        public void Salario_nao_Pode_Ser_menor_Zero()
        {
            Funcionario funcionario = new("Funcionario", default, DateTime.Parse("26/06/2022"), "Senha1", "Login1", true);

            ValidadorFuncionario validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(funcionario);

            //assert
            Assert.AreEqual("Salario não pode ser menor que zero", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void DataAdmissao_nao_Pode_Ser_menor_Hoje()
        {
            Funcionario funcionario = new("Funcionario", 1000, DateTime.Parse("26/07/2022"), "Senha1", "Login1", true);

            ValidadorFuncionario validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(funcionario);

            //assert
            Assert.AreEqual("Data de Admissão não pode ser Maior que hoje", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Senha_nao_Pode_Ser_Nulo()
        {
            Funcionario funcionario = new("Funcionario", 1000, DateTime.Parse("26/06/2022"), null, "Login1", true);

            ValidadorFuncionario validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(funcionario);

            //assert
            Assert.AreEqual("Senha não pode ser nulo", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Senha_nao_Pode_Ser_Vazio()
        {
            Funcionario funcionario = new("Funcionario", 1000, DateTime.Parse("26 /06/2022"), "", "Login1", true);

            ValidadorFuncionario validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(funcionario);

            //assert
            Assert.AreEqual("Senha não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Senha_Deve_Ter_Minimo_Dois_Caracteres()
        {
            Funcionario funcionario = new("Funcionario", 1000, DateTime.Parse("26/06/2022"), "S", "Login1", true);

            ValidadorFuncionario validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(funcionario);

            //assert
            Assert.AreEqual("Senha deve ter no mínimo 2 caracteres", resultado.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void Login_nao_Pode_Ser_Nulo()
        {
            Funcionario funcionario = new("Funcionario", 1000, DateTime.Parse("26/06/2022"), "Senha1", null, true);

            ValidadorFuncionario validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(funcionario);

            //assert
            Assert.AreEqual("Login não pode ser nulo", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Login_nao_Pode_Ser_Vazio()
        {
            Funcionario funcionario = new("Funcionario", 1000, DateTime.Parse("26 /06/2022"), "Senha1", "", true);

            ValidadorFuncionario validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(funcionario);

            //assert
            Assert.AreEqual("Login não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Login_Deve_Ter_Minimo_Dois_Caracteres()
        {
            Funcionario funcionario = new("Funcionario", 1000, DateTime.Parse("26/06/2022"), "Senha1", "L", true);

            ValidadorFuncionario validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(funcionario);

            //assert
            Assert.AreEqual("Login deve ter no mínimo 2 caracteres", resultado.Errors[0].ErrorMessage);
        }

    }
}
