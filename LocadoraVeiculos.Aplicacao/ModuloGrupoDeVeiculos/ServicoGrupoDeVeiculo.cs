using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraVeiculos.Aplicacao.ModuloGrupoDeVeiculos
{
    public class ServicoGrupoDeVeiculo
    {

        private IRepositorioGrupoDeVeiculo repositorioGrupoDeVeiculo;

        public ServicoGrupoDeVeiculo(IRepositorioGrupoDeVeiculo repositorioGrupoDeVeiuculo)
        {
            this.repositorioGrupoDeVeiculo = repositorioGrupoDeVeiuculo;
        }


        public Result<GrupoDeVeiculo> Inserir(GrupoDeVeiculo grupoDeVeiculo)
        {
            Log.Logger.Debug("Tentando inserir grupo de veículo... {@g}", grupoDeVeiculo);

            Result resultadoValidacao = Validar(grupoDeVeiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o grupo de veículo {grupoVeiculoId} - {Motivo}",
                       grupoDeVeiculo.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioGrupoDeVeiculo.Inserir(grupoDeVeiculo);

                Log.Logger.Information("Grupo de veículo {grupoVeiculoId} inserido com sucesso", grupoDeVeiculo.Id);

                return Result.Ok(grupoDeVeiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o grupo de veículo";

                Log.Logger.Error(ex, msgErro + "{grupoVeiculoId}", grupoDeVeiculo.Id);

                return Result.Fail(msgErro);
            }

        }



        public Result<GrupoDeVeiculo> Editar(GrupoDeVeiculo grupoVeiculo)
        {
            Log.Logger.Debug("Tentando editar grupo de veículo... {@g}", grupoVeiculo);

            Result resultadoValidacao = Validar(grupoVeiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o grupo de veículo {grupoVeiculoId} - {Motivo}",
                       grupoVeiculo.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioGrupoDeVeiculo.Editar(grupoVeiculo);

                Log.Logger.Information("Grupo de veículo {grupoVeiculoId} editado com sucesso", grupoVeiculo.Id);

                return Result.Ok(grupoVeiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o grupo de veículo";

                Log.Logger.Error(ex, msgErro + "{grupoVeiculoId}", grupoVeiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(GrupoDeVeiculo grupoVeiculo)
        {
            Log.Logger.Debug("Tentando excluir grupo de veículo... {@g}", grupoVeiculo);

            try
            {
                repositorioGrupoDeVeiculo.Excluir(grupoVeiculo);

                Log.Logger.Information("Grupo de veículo {grupoVeiculoId} excluído com sucesso", grupoVeiculo.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o grupo de veículo";

                Log.Logger.Error(ex, msgErro + "{grupoVeiculoId}", grupoVeiculo.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<GrupoDeVeiculo>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioGrupoDeVeiculo.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os grupos de veículo";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<GrupoDeVeiculo> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioGrupoDeVeiculo.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o grupo de veículo";

                Log.Logger.Error(ex, msgErro + "{grupoVeiculoId}", id);

                return Result.Fail(msgErro);
            }
        }



        private Result Validar(GrupoDeVeiculo grupoVeiculo)
        {
            var validador = new ValidadorGrupoDeVeiculo();

            var resultadoValidacao = validador.Validate(grupoVeiculo);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            if (NomeDuplicado(grupoVeiculo))
                erros.Add(new Error("Nome duplicado"));            

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }



        private bool NomeDuplicado(LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos.GrupoDeVeiculo grupoDeVeiculo)
        {
            var GrupoDeVeiculoEncontrado = repositorioGrupoDeVeiculo.SelecionarGrupoDeVeiculoPorNome(grupoDeVeiculo.Nome);

            return GrupoDeVeiculoEncontrado != null &&
                   GrupoDeVeiculoEncontrado.Nome == grupoDeVeiculo.Nome &&
                   GrupoDeVeiculoEncontrado.Id != grupoDeVeiculo.Id;
        }


    }
}
