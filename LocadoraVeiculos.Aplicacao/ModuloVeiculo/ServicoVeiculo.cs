using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo : ServicoBase<Veiculo>
    {
        public ServicoVeiculo(RepositorioVeiculoOrm repositorio) : base(repositorio)
        {
        }

        public override Result Validar(Veiculo veiculo)
        {
            var validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            if (PlacaDuplicado(veiculo))
                erros.Add(new Error("Placa duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool PlacaDuplicado(Veiculo veiculo)
        {
            var funcionarioEncontrado = repositorio.SelecionarPorParametro(x => x.Placa == veiculo.Placa);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Placa == veiculo.Placa &&
                   funcionarioEncontrado.Id != veiculo.Id;
        }

    }
}
