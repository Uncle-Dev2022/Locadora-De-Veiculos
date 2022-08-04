using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloLocacao
{
    public class ServicoLocacao : ServicoBase<Locacao>
    {
        public ServicoLocacao(IRepositorioLocacao repositorio, IContextoPersistencia contextoPersistencia) : base(repositorio, contextoPersistencia)
        {
        }

        public override Result Validar(Locacao locacao)
        {
            var validador = new ValidadorLocacao();

            var resultadoValidacao = validador.Validate(locacao);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors)//FluentValidation       
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (erros.Any())
            {
                contextoPersistencia.DesfazerAlteracoes();
                return Result.Fail(erros);
            }

            return Result.Ok();
        }
    }
}
