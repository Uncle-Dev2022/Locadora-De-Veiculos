using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Aplicacao.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloTaxas
{
    public class ServicoTaxa : ServicoBase<Taxa>
    {
        public ServicoTaxa(IRepositorioTaxa repositorio, IContextoPersistencia contextoPersistencia) : base(repositorio, contextoPersistencia)
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
            {
                contextoPersistencia.DesfazerAlteracoes();
                return Result.Fail(erros);
            }

            return Result.Ok();
        }
        private bool DescricaoDuplicada(Taxa taxa)
        {
            var taxaEncontrada = repositorio.SelecionarPorParametro(x => x.descricao == taxa.descricao);

            return taxaEncontrada != null &&
                   taxaEncontrada.descricao == taxa.descricao &&
                   taxaEncontrada.Id != taxa.Id;
        }
    }
}
