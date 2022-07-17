using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca
    {
        private IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;

        public ServicoPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioGrupoDeVeiuculo)
        {
            this.repositorioPlanoDeCobranca = repositorioGrupoDeVeiuculo;
        }

        public Result<PlanoDeCobranca> Inserir(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Tentando inserir Plano De Cobrança... {@p}", planoDeCobranca);

            Result resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Plano De Cobrança {PlanoDeCobrancaId} - {Motivo}",
                       planoDeCobranca.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                repositorioPlanoDeCobranca.Inserir(planoDeCobranca);

                Log.Logger.Information("Plano de Cobrança {PlanoDeCobrancaId} inserido com sucesso", planoDeCobranca.Id);

                return Result.Ok(planoDeCobranca);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o Plano de Cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<PlanoDeCobranca> Editar(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Tentando editar planoDeCobranca... {@c}", planoDeCobranca);

            Result resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o planoDeCobranca {planoDeCobrancaId} - {Motivo}",
                       planoDeCobranca.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlanoDeCobranca.Editar(planoDeCobranca);

                Log.Logger.Information("planoDeCobranca {planoDeCobrancaId} editado com sucesso", planoDeCobranca.Id);

                return Result.Ok(planoDeCobranca);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o planoDeCobranca";

                Log.Logger.Error(ex, msgErro + "{planoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Tentando excluir Plano De Cobrança... {@c}", planoDeCobranca);

            try
            {
                repositorioPlanoDeCobranca.Excluir(planoDeCobranca);

                Log.Logger.Information("Plano De Cobrança{PlanoDeCobrancaId} excluído com sucesso", planoDeCobranca.Id);

                return Result.Ok();
            }
            /*
            catch (NaoPodeExcluirEsteRegistroException ex)
            {
                string msgErro = $"O Plano De Cobrança: {planoDeCobranca.Nome}, esta relacionado com um condutor e não pode ser excluido";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }*/
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o Plano De Cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result<List<PlanoDeCobranca>> SelecionarTodos()
        {

            try
            {
                return Result.Ok(repositorioPlanoDeCobranca.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar Selecionar todos os Planos De Cobrança";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }

        }
        public Result<PlanoDeCobranca> SelecionarPorId(Guid id)
        {

            try
            {
                return Result.Ok(repositorioPlanoDeCobranca.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar Selecionar o Plano De Cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaID}", id);

                return Result.Fail(msgErro);
            }

        }
        private Result Validar(PlanoDeCobranca PlanoDeCobranca)
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
                return Result.Fail(erros);
            return Result.Ok();
            
        }

        private bool NomeDuplicado(PlanoDeCobranca planoDeCobranca)
        {
            var PlanoDeCobrancaEncontrado = repositorioPlanoDeCobranca.SelecionarPlanoDeCobrancaPorNome(planoDeCobranca.Nome);

            return PlanoDeCobrancaEncontrado != null &&
                   PlanoDeCobrancaEncontrado.Nome == planoDeCobranca.Nome &&
                   PlanoDeCobrancaEncontrado.Id != planoDeCobranca.Id;
        }
    }
}
