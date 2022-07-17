using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private IRepositorioCliente repositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public Result<Cliente> Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir cliente... {@c}", cliente);

            Result resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Cliente {ClienteId} - {Motivo}",
                       cliente.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Inserir(cliente);

                Log.Logger.Information("Cliente {ClienteId} inserido com sucesso", cliente.Id);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> Editar(Cliente cliente)
        {
            Log.Logger.Debug("Tentando editar cliente... {@c}", cliente);

            Result resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o cliente {ClienteId} - {Motivo}",
                       cliente.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Editar(cliente);

                Log.Logger.Information("Cliente {ClienteId} editado com sucesso", cliente.Id);

                return Result.Ok(cliente);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando excluir cliente... {@c}", cliente);

            try
            {
                repositorioCliente.Excluir(cliente);

                Log.Logger.Information("Cliente {ClienteId} excluído com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch(NaoPodeExcluirEsteRegistroException ex)
            {
                string msgErro = $"O Cliente: {cliente.Nome}, esta relacionado com um condutor e não pode ser excluido";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o Cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", cliente.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result<List<Cliente>> SelecionarTodos()
        {            
            try
            {
                return Result.Ok(repositorioCliente.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar Selecionar todos os Cliente";

                Log.Logger.Error(ex,msgErro);

                return Result.Fail(msgErro);
            }

        }

        public Result<Cliente> SelecionarPorId(Guid id)
        {

            try
            {
                return Result.Ok(repositorioCliente.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar Selecionar o Cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteID}",id);

                return Result.Fail(msgErro);
            }

        }

        private Result Validar(Cliente cliente)
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
