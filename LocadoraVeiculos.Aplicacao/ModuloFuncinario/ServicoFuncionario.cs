using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionário;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloFuncinario
{
    public class ServicoFuncionario : ServicoBase<Funcionario>
    {
        public ServicoFuncionario(RepositorioFuncionarioOrm repositorio) : base(repositorio)
        {
        }

        public override Result Validar(Funcionario funcionario)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(funcionario);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            if (NomeDuplicado(funcionario))
                erros.Add(new Error("Nome duplicado"));

            if (LoginDuplicado(funcionario))
                erros.Add(new Error("Login duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorio.SelecionarPorParametro(x => x.Nome == funcionario.Nome);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome == funcionario.Nome &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }

        private bool LoginDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorio.SelecionarPorParametro(x => x.Login == funcionario.Login);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Login == funcionario.Login &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }




    }
}
