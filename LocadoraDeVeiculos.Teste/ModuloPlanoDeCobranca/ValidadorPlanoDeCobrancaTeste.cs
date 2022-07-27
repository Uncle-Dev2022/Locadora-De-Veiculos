using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloPlanoDeCobranca
{
    [TestClass]
    public class ValidadorPlanoDeCobrancaTeste
    {
        [TestMethod]
        public void Nome_Nao_Pode_Ser_Nulo_Vazio()
        {
            GrupoDeVeiculo grupoDeVeiculo = new GrupoDeVeiculo("Usados");

            PlanoLivre planoLivre = new PlanoLivre(229.99m);
            PlanoDiario planoDiario = new PlanoDiario(229.99m, 6.30m);
            PlanoControlado planoControlado = new PlanoControlado(159.99m, 5.99m, 300);

            PlanoDeCobranca planoDeCobranca = new PlanoDeCobranca()
            {
                Nome = "",
                grupoDeVeiculo = grupoDeVeiculo,
                planoLivre = planoLivre, 
                planoDiario = planoDiario,
                planoControlado = planoControlado
            };

            PlanoDeCobranca planoDeCobranca1 = new PlanoDeCobranca()
            {
                Nome = null,
                grupoDeVeiculo = grupoDeVeiculo,
                planoLivre = planoLivre,
                planoDiario = planoDiario,
                planoControlado = planoControlado
            };

            ValidadorPlanoDeCobranca validacao = new ValidadorPlanoDeCobranca();

            //action
            ValidationResult resultado = validacao.Validate(planoDeCobranca);
            ValidationResult resultado1 = validacao.Validate(planoDeCobranca1);
            //assert
            Assert.AreEqual("O Nome do Plano não pode ser Vazio!", resultado.Errors[0].ErrorMessage);
            
            Assert.AreEqual("O Nome do Plano não pode ser Nulo!", resultado1.Errors[0].ErrorMessage);
        }
        [TestMethod]
        public void Valor_Nao_Pode_Ser_Menor_Igual_0()
        {
            GrupoDeVeiculo grupoDeVeiculo = new GrupoDeVeiculo("Usados");

            PlanoLivre planoLivre = new PlanoLivre(229.99m);
            PlanoDiario planoDiario = new PlanoDiario(229.99m, 6.30m);
            PlanoControlado planoControlado = new PlanoControlado(159.99m, 5.99m, 300);

            PlanoLivre planoLivre1 = new PlanoLivre(-1m);
            PlanoDiario planoDiario1 = new PlanoDiario(229.99m, 0m);
            PlanoControlado planoControlado1 = new PlanoControlado(159.99m, 5.99m, 0m);

            PlanoDeCobranca planoDeCobranca = new PlanoDeCobranca()
            {
                Nome = "Cobrança de Usados",
                grupoDeVeiculo = grupoDeVeiculo,
                planoLivre = planoLivre1,
                planoDiario = planoDiario,
                planoControlado = planoControlado
            };

            PlanoDeCobranca planoDeCobranca1 = new PlanoDeCobranca()
            {
                Nome = "Cobrança de Usados",
                grupoDeVeiculo = grupoDeVeiculo,
                planoLivre = planoLivre,
                planoDiario = planoDiario1,
                planoControlado = planoControlado
            };

            PlanoDeCobranca planoDeCobranca2 = new PlanoDeCobranca()
            {
                Nome = "Cobrança de Usados",
                grupoDeVeiculo = grupoDeVeiculo,
                planoLivre = planoLivre,
                planoDiario = planoDiario,
                planoControlado = planoControlado1
            };

            ValidadorPlanoDeCobranca validacao = new ValidadorPlanoDeCobranca();

            //action
            ValidationResult resultado = validacao.Validate(planoDeCobranca);
            ValidationResult resultado1 = validacao.Validate(planoDeCobranca1);
            ValidationResult resultado2 = validacao.Validate(planoDeCobranca2);
            //assert
            Assert.AreEqual("O Plano Livre não pode conter planos que custam 0 ou menos", resultado.Errors[0].ErrorMessage);

            Assert.AreEqual("O Plano Diário não pode conter planos que custam 0 ou menos", resultado1.Errors[0].ErrorMessage);

            Assert.AreEqual("O Plano Controlado não pode conter planos que custam 0 ou menos / Limite De KM menor igual 0", resultado2.Errors[0].ErrorMessage);

        }
        [TestMethod]
        public void Plano_Nao_Pode_Ser_Vazio_Nulo()
        {
            GrupoDeVeiculo grupoDeVeiculo = new GrupoDeVeiculo("Usados");

            PlanoLivre planoLivre = null;
            PlanoDiario planoDiario = null;
            PlanoControlado planoControlado = null;

            PlanoDeCobranca planoDeCobranca = new PlanoDeCobranca()
            {
                Nome = "Cobrança de Usados",
                grupoDeVeiculo = grupoDeVeiculo,
                planoLivre = planoLivre,
                planoDiario = planoDiario,
                planoControlado = planoControlado
            };
            
            ValidadorPlanoDeCobranca validacao = new ValidadorPlanoDeCobranca();

            //action
            ValidationResult resultado = validacao.Validate(planoDeCobranca);
            //assert
            Assert.AreEqual("O Plano Controlado não pode ser Nulo!", resultado.Errors[0].ErrorMessage);

            Assert.AreEqual("O Plano Diário não pode ser Nulo!", resultado.Errors[1].ErrorMessage);

            Assert.AreEqual("O Plano Livre não pode ser Nulo!", resultado.Errors[2].ErrorMessage);
        }
        [TestMethod]
        public void GrupoDeVeiculos_Nao_Pode_Ser_Vazio_Nulo()
        {
            GrupoDeVeiculo grupoDeVeiculo = null;

            PlanoLivre planoLivre = new PlanoLivre(229.99m);
            PlanoDiario planoDiario = new PlanoDiario(229.99m, 6.30m);
            PlanoControlado planoControlado = new PlanoControlado(159.99m, 5.99m, 300);

            PlanoDeCobranca planoDeCobranca = new PlanoDeCobranca()
            {
                Nome = "Cobrança de Usados",
                grupoDeVeiculo = grupoDeVeiculo,
                planoLivre = planoLivre,
                planoDiario = planoDiario,
                planoControlado = planoControlado
            };

            ValidadorPlanoDeCobranca validacao = new ValidadorPlanoDeCobranca();

            //action
            ValidationResult resultado = validacao.Validate(planoDeCobranca);
            //assert
            Assert.AreEqual("O Grupo De Veículo não pode ser Nulo!", resultado.Errors[0].ErrorMessage);
        }
        [TestMethod]
        public void GrupoDeVeiculos_Validador()
        {
            GrupoDeVeiculo grupoDeVeiculo = new GrupoDeVeiculo("");

            PlanoLivre planoLivre = new PlanoLivre(229.99m);
            PlanoDiario planoDiario = new PlanoDiario(229.99m, 6.30m);
            PlanoControlado planoControlado = new PlanoControlado(159.99m, 5.99m, 300);

            PlanoDeCobranca planoDeCobranca = new PlanoDeCobranca()
            {
                Nome = "Cobrança de Usados",
                grupoDeVeiculo = grupoDeVeiculo,
                planoLivre = planoLivre,
                planoDiario = planoDiario,
                planoControlado = planoControlado
            };

            grupoDeVeiculo.Nome = null;
            PlanoDeCobranca planoDeCobranca1 = new PlanoDeCobranca()
            {
                Nome = "Cobrança de Usados",
                grupoDeVeiculo = grupoDeVeiculo,
                planoLivre = planoLivre,
                planoDiario = planoDiario,
                planoControlado = planoControlado
            };
            grupoDeVeiculo.Nome = "a";
            PlanoDeCobranca planoDeCobranca2 = new PlanoDeCobranca()
            {
                Nome = "Cobrança de Usados",
                grupoDeVeiculo = grupoDeVeiculo,
                planoLivre = planoLivre,
                planoDiario = planoDiario,
                planoControlado = planoControlado
            };

            ValidadorPlanoDeCobranca validacao = new ValidadorPlanoDeCobranca();

            //action
            ValidationResult resultado = validacao.Validate(planoDeCobranca);
            ValidationResult resultado1 = validacao.Validate(planoDeCobranca1);
            ValidationResult resultado2 = validacao.Validate(planoDeCobranca2);
            //assert            
            Assert.AreEqual("Nome deve ter no mínimo 2 caracteres", resultado.Errors[0].ErrorMessage);
            Assert.AreEqual("Nome deve ter no mínimo 2 caracteres", resultado1.Errors[0].ErrorMessage);
            Assert.AreEqual("Nome deve ter no mínimo 2 caracteres", resultado2.Errors[0].ErrorMessage);
            
        }
    }
}
