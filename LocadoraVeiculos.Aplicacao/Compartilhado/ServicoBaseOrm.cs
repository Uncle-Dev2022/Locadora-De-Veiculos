using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.Compartilhado
{
    public abstract class ServicoBase<T> where T : EntidadeBase<T>
    {
        protected IRepositorio<T> repositorio;
        public ServicoBase(IRepositorio<T> repositorio)
        {
            this.repositorio = repositorio;
        }
        public virtual Result<T> Inserir(T registro)
        {
            Log.Logger.Debug("Tentando Inserir {@r}...", registro);

            Result resultado = Validar(registro);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                repositorio.Inserir(registro);
                repositorio.GravarDados();
                Log.Logger.Information("{@T} {@T_Id} inserido(a) com sucesso", registro, registro.Id);
                return Result.Ok(registro);
            }
            catch (Exception ex)
            {
                string msgErro = string.Format("Falha no sistema ao tentar inserir o/a {@T}", registro);

                Log.Logger.Error(ex, msgErro + " {@T_Id}", registro.Id);
                return Result.Fail(msgErro);
            }
        }
        public Result<T> Editar(T registro)
        {
            Log.Logger.Debug("Tentando Editar {@r}...", registro);

            Result resultado = Validar(registro);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                repositorio.Editar(registro);
                repositorio.GravarDados();
                Log.Logger.Information("{@T} {@T_Id} editado(a) com sucesso", registro, registro.Id);
                return Result.Ok(registro);
            }
            catch (Exception ex)
            {
                string msgErro = string.Format("Falha no sistema ao tentar editar o/a {@T}", registro);

                Log.Logger.Error(ex, msgErro + " {@T_Id}", registro.Id);
                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(T registro)
        {
            Log.Logger.Debug("Tentando Excluir {@r}...", registro);

            Result resultado = Validar(registro);

            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                repositorio.Excluir(registro);
                repositorio.GravarDados();
                Log.Logger.Information("{@T} {@T_Id} excluído(a) com sucesso", registro, registro.Id);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = string.Format("Falha no sistema ao tentar excluir o/a {@T}", registro);

                Log.Logger.Error(ex, msgErro + " {Id}" + registro.Id);
                return Result.Fail(msgErro);
            }
        }
        public Result<List<T>> SelecionarTodos()
        {
            Log.Logger.Debug("Tentando Selecionar todos os(as) {@Registros}...", typeof(T));

            try
            {
                var registros = repositorio.SelecionarTodos();

                Log.Logger.Information("{@Registros}s selecionados com sucesso", typeof(T));

                return Result.Ok(registros);
            }
            catch (Exception ex)
            {
                string msgErro = string.Format("Falha no sistema ao tentar Selecionar todos os {@Registros}s", typeof(T));

                Log.Logger.Error(ex, msgErro + " {@T_Id}");
                return Result.Fail(msgErro);
            }
        }
        public Result<T> SelecionarPorId(Guid id)
        {
            try
            {
                var registro = repositorio.SelecionarPorId(id);

                if (registro == null)
                {
                    Log.Logger.Warning("{@Registro} {@RegistroId} não encontrado", registro, id);

                    return Result.Fail(registro.ToString() + " não encontrado");
                }

                Log.Logger.Information("{@Registro} {@RegistroId} selecionado com sucesso", registro, id);

                return Result.Ok(registro);
            }
            catch (Exception ex)
            {
                string msgErro = String.Format("Falha no sistema ao tentar selecionar o {@Registro}", typeof(T));

                Log.Logger.Error(ex, msgErro + " {@RegistroId}", id);

                return Result.Fail(msgErro);
            }
        }
        public abstract Result Validar(T registro);

    }
}
