using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca : ServicoBase<PlanoDeCobranca>
    {
        public ServicoPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorio, IContextoPersistencia contextoPersistencia) : base(repositorio, contextoPersistencia)
        {
        }

        public override Result Validar(PlanoDeCobranca PlanoDeCobranca)
        {
            var validador = new ValidadorPlanoDeCobranca();

            var resultadoValidacao = validador.Validate(PlanoDeCobranca);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(PlanoDeCobranca))
                erros.Add(new Error("Nome duplicado"));

            if (erros.Any())
            {
                contextoPersistencia.DesfazerAlteracoes();
                return Result.Fail(erros);
            }

            return Result.Ok();

        }

        private bool NomeDuplicado(PlanoDeCobranca planoDeCobranca)
        {
            var PlanoDeCobrancaEncontrado = repositorio.SelecionarPorParametro(x => x.Nome == planoDeCobranca.Nome);

            return PlanoDeCobrancaEncontrado != null &&
                   PlanoDeCobrancaEncontrado.Nome == planoDeCobranca.Nome &&
                   PlanoDeCobrancaEncontrado.Id != planoDeCobranca.Id;
        }
    }
}
