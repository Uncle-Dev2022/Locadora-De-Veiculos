using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraVeiculos.Aplicacao.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente : ServicoBase<Cliente>
    {
        private IRepositorioCliente repositorioCliente;

        public ServicoCliente(RepositorioBaseOrm<Cliente, MapeadorClienteOrm> repositorio) : base(repositorio)
        {
            repositorioCliente = (IRepositorioCliente)repositorio;
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
            var ClienteEncontrado = repositorioCliente.SelecionarClientePorCPFOuCNPJ(cliente.CPF_CNPJ);

            return ClienteEncontrado != null &&
                   ClienteEncontrado.CPF_CNPJ == cliente.CPF_CNPJ &&
                   ClienteEncontrado.Id != cliente.Id;
        }

        private bool NomeDuplicado(Cliente cliente)
        {
            var ClienteEncontrado = repositorioCliente.SelecionarClientePorNome(cliente.Nome);

            return ClienteEncontrado != null &&
                   ClienteEncontrado.Nome == cliente.Nome &&
                   ClienteEncontrado.Id != cliente.Id;
        }
    }
}
