using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloVeiculo
{
    [TestClass]
    public class ValidadorVeiculoTeste
    {
        [TestMethod]
        public void Marca_nao_Pode_Ser_Nulo()
        {
            Veiculo veiculo = new(null, "Ka", "Vermelho", "2015", "Gasolina", "BRA2E19", 1000000, 50, new byte[] { });

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Marca não pode ser nulo", resultado.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void Marca_nao_Pode_Ser_Vazio()
        {
            Veiculo veiculo = new("", "Ka", "Vermelho", "2015", "Gasolina", "BRA2E19", 1000000, 50, new byte[] { });

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Marca não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void Modelo_nao_Pode_Ser_Nulo()
        {
            Veiculo veiculo = new("Ford", null, "Vermelho", "2015", "Gasolina", "BRA2E19", 1000000, 50, new byte[] { });

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Modelo não pode ser nulo", resultado.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void Modelo_nao_Pode_Ser_Vazio()
        {
            Veiculo veiculo = new("Ford", "", "Vermelho", "2015", "Gasolina", "BRA2E19", 1000000, 50, new byte[] { });

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Modelo não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Cor_nao_Pode_Ser_Nulo()
        {
            Veiculo veiculo = new("Ford", "Ka", null, "2015", "Gasolina", "BRA2E19", 1000000, 50, new byte[] { });

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Cor não pode ser nulo", resultado.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void Cor_nao_Pode_Ser_Vazio()
        {
            Veiculo veiculo = new("Ford", "Ka", "", "2015", "Gasolina", "BRA2E19", 1000000, 50, new byte[] { });

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Cor não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void AnoModelo_nao_Pode_Ser_Nulo()
        {
            Veiculo veiculo = new("Ford", "Ka", "Vermelho", null, "Gasolina", "BRA2E19", 1000000, 50, new byte[] { });

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Ano Modelo não pode ser nulo", resultado.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void AnoModelo_nao_Pode_Ser_Vazio()
        {
            Veiculo veiculo = new("Ford", "Ka", "Vermelho", "", "Gasolina", "BRA2E19", 1000000, 50, new byte[] { });

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Ano Modelo não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void TipoCombustivel_nao_Pode_Ser_Nulo()
        {
            Veiculo veiculo = new("Ford", "Ka", "Vermelho", "2015", null, "BRA2E19", 1000000, 50, new byte[] { });

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Tipo Combustivel não pode ser nulo", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void TipoCombustivel_nao_Pode_Ser_Vazio()
        {
            Veiculo veiculo = new("Ford", "Ka", "Vermelho", "2015", "", "BRA2E19", 1000000, 50, new byte[] { });

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Tipo Combustivel não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }



        [TestMethod]
        public void Placa_nao_Pode_Ser_Nulo()
        {
            Veiculo veiculo = new("Ford", "Ka", "Vermelho", "2015", "Gasolina", null, 1000000, 50, new byte[] { });

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Placa não pode ser nulo", resultado.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void Placa_nao_Pode_Ser_Vazio()
        {
            Veiculo veiculo = new("Ford", "Ka", "Vermelho", "2015", "Gasolina", "", 1000000, 50, new byte[] { });

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Placa não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Quilometragem_nao_Pode_Ser_Nulo()
        {
            Veiculo veiculo = new("Ford", "Ka", "Vermelho", "2015", "Gasolina", "BRA2E19", default, 50, new byte[] { });

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Quilometragem não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void CapacidadeTanque_nao_Pode_Ser_Nulo()
        {
            Veiculo veiculo = new("Ford", "Ka", "Vermelho", "2015", "Gasolina", "BRA2E19", 100000, default, new byte[] { });

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Capacidade Tanque não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Imagem_nao_Pode_Ser_Nulo()
        {
            Veiculo veiculo = new("Ford", "Ka", "Vermelho", "2015", "Gasolina", "BRA2E19", 100000, 50, null);

            ValidadorVeiculo validacao = new();

            //action
            ValidationResult resultado = validacao.Validate(veiculo);

            //assert
            Assert.AreEqual("Imagem não pode ser vazio", resultado.Errors[0].ErrorMessage);
        }
    }
}
