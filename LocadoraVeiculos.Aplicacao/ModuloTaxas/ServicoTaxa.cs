using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.ModuloTaxas;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloTaxas
{
    public class ServicoTaxa : ServicoBase<Taxa>
    {
        public ServicoTaxa(IRepositorio<Taxa> repositorio) : base(repositorio)
        {
        }
        public override Result Validar(Taxa taxa)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors)//FluentValidation       
            {
                erros.Add(new Error(item.ErrorMessage));
            }


            if (DescricaoDuplicada(taxa))
                erros.Add(new Error("Nome Duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }
        private bool DescricaoDuplicada(Taxa taxa)
        {
            var taxaEncontrada = repositorio.SelecionarPorParametro(x=> x.descricao == taxa.descricao);

            return taxaEncontrada != null &&
                   taxaEncontrada.descricao == taxa.descricao &&
                   taxaEncontrada.Id != taxa.Id;
        }
    }
}
