using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraVeiculos.Aplicacao.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente : ServicoBase<Cliente>
    {

        public ServicoCliente(IRepositorioCliente repositorio,IContextoPersistencia contextoPersistencia) : base(repositorio,contextoPersistencia)
        {

        }

        public override Result Validar(Cliente cliente)
        {
            var validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors)//FluentValidation       
            {
                erros.Add(new Error(item.ErrorMessage));
            }


            if (NomeDuplicado(cliente))
                erros.Add(new Error("Nome Duplicado"));

            if (CPF_CNPJDuplicado(cliente))
            {
                if (cliente.tipoCliente == true)
                    erros.Add(new Error("CPF Duplicado"));
                else
                    erros.Add(new Error("CNPJ Duplicado"));
            }

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool CPF_CNPJDuplicado(Cliente cliente)
        {
            var ClienteEncontrado = repositorio.SelecionarPorParametro(x => x.CPF_CNPJ == cliente.CPF_CNPJ);

            return ClienteEncontrado != null &&
                   ClienteEncontrado.CPF_CNPJ == cliente.CPF_CNPJ &&
                   ClienteEncontrado.Id != cliente.Id;
        }

        private bool NomeDuplicado(Cliente cliente)
        {
            var ClienteEncontrado = repositorio.SelecionarPorParametro(x => x.Nome == cliente.Nome);

            return ClienteEncontrado != null &&
                   ClienteEncontrado.Nome == cliente.Nome &&
                   ClienteEncontrado.Id != cliente.Id;
        }
    }
}
