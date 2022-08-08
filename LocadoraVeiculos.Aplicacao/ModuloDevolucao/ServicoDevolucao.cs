using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.Orm.ModuloDevolucao;
using LocadoraVeiculos.Aplicacao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloDevolucao
{
    public class ServicoDevolucao : ServicoBase<Devolucao>
    {
        public ServicoDevolucao(IRepositorioDevolucao repositorio, IContextoPersistencia contextoPersistencia)
            : base(repositorio, contextoPersistencia)
        {
        }

        public override Result Validar(Devolucao devolucao)
        {
            var validador = new ValidarDevolucao();

            var resultadoValidacao = validador.Validate(devolucao);

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
