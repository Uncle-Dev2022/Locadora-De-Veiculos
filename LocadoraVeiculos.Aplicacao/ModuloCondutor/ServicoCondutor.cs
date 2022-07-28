﻿using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor : ServicoBase<Condutor>
    {
        public ServicoCondutor(IRepositorio<Condutor> repositorio) : base(repositorio)
        {
        }

        public override Result Validar(Condutor condutor)
        {
            var validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors)//FluentValidation       
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(condutor))
                erros.Add(new Error("Nome Duplicado"));

            if (CPFDuplicado(condutor))
                erros.Add(new Error("CPF Duplicado"));

            if (CNHDuplicada(condutor))
                erros.Add(new Error("CNH Duplicada"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool CPFDuplicado(Condutor condutor)
        {
            var CondutorEncontrado = repositorio.SelecionarPorParametro(x => x.CPF == condutor.CPF);

            return CondutorEncontrado != null &&
                   CondutorEncontrado.CPF == condutor.CPF &&
                   CondutorEncontrado.Id != condutor.Id;
        }

        private bool NomeDuplicado(Condutor condutor)
        {
            var CondutorEncontrado = repositorio.SelecionarPorParametro(x => x.Nome == condutor.Nome);

            return CondutorEncontrado != null &&
                   CondutorEncontrado.Nome == condutor.Nome &&
                   CondutorEncontrado.Id != condutor.Id;
        }

        private bool CNHDuplicada(Condutor condutor)
        {
            var CondutorEncontrado = repositorio.SelecionarPorParametro(x => x.CNH == condutor.CNH);

            return CondutorEncontrado != null &&
                   CondutorEncontrado.CNH == condutor.CNH &&
                   CondutorEncontrado.Id != condutor.Id;
        }
    }
}
