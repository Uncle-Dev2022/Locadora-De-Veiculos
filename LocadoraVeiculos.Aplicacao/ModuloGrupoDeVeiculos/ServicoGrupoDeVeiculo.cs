using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculos;
using LocadoraVeiculos.Aplicacao.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloGrupoDeVeiculos
{
    public class ServicoGrupoDeVeiculo : ServicoBase<GrupoDeVeiculo>
    {
        public ServicoGrupoDeVeiculo(IRepositorioGrupoDeVeiculo repositorio) : base(repositorio)
        {
        }

        public override Result Validar(GrupoDeVeiculo grupoVeiculo)
        {
            var validador = new ValidadorGrupoDeVeiculo();

            var resultadoValidacao = validador.Validate(grupoVeiculo);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            if (NomeDuplicado(grupoVeiculo))
                erros.Add(new Error("Nome duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }



        private bool NomeDuplicado(LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos.GrupoDeVeiculo grupoDeVeiculo)
        {
            var GrupoDeVeiculoEncontrado = repositorio.SelecionarPorParametro(x => x.Nome == grupoDeVeiculo.Nome);

            return GrupoDeVeiculoEncontrado != null &&
                   GrupoDeVeiculoEncontrado.Nome == grupoDeVeiculo.Nome &&
                   GrupoDeVeiculoEncontrado.Id != grupoDeVeiculo.Id;
        }


    }
}
