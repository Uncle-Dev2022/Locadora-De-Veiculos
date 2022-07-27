using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private IRepositorioCondutor repositorioCondutor;
        private IContextoPersistencia ContextoPersistencia;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioCondutor = repositorioCondutor;
            ContextoPersistencia = contextoPersistencia;
        }

        public Result<Condutor> Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir condutor... {@c}", condutor);

            Result resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o condutor {condutorId} - {Motivo}",
                       condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Inserir(condutor);

                Log.Logger.Information("condutor {condutorId} inserido com sucesso", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o condutor";

                Log.Logger.Error(ex, msgErro + "{condutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar condutor... {@c}", condutor);

            Result resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o condutor {condutorId} - {Motivo}",
                       condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Editar(condutor);

                Log.Logger.Information("condutor {condutorId} editado com sucesso", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o condutor";

                Log.Logger.Error(ex, msgErro + "{condutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando excluir condutor... {@c}", condutor);

            try
            {
                repositorioCondutor.Excluir(condutor);

                Log.Logger.Information("condutor {condutorId} excluído com sucesso", condutor.Id);

                return Result.Ok();
            }
            catch (NaoPodeExcluirEsteRegistroException ex)
            {
                string msgErro = $"O condutor: {condutor.Nome}, esta relacionado com um {"algumacoisa"} e não pode ser excluido";

                Log.Logger.Error(ex, msgErro + "{condutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o condutor";

                Log.Logger.Error(ex, msgErro + "{condutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result<List<Condutor>> SelecionarTodos()
        {

            try
            {
                return Result.Ok(repositorioCondutor.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar Selecionar todos os condutores";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }

        }

        public Result<Condutor> SelecionarPorId(Guid id)
        {

            try
            {
                return Result.Ok(repositorioCondutor.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar Selecionar o condutor";

                Log.Logger.Error(ex, msgErro + "{condutorId}", id);

                return Result.Fail(msgErro);
            }

        }
        private Result Validar(Condutor condutor)
        {
            var validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors)//FluentValidation       
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(condutor))
                erros.Add(new Error("Nome Duplicado"));

            if(CPFDuplicado(condutor))
                erros.Add(new Error("CPF Duplicado"));

            if(CNHDuplicada(condutor))
                erros.Add(new Error("CNH Duplicada"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool CPFDuplicado(Condutor condutor)
        {
            var CondutorEncontrado = repositorioCondutor.SelecionarCondutorPorCPF(condutor.CPF);

            return CondutorEncontrado != null &&
                   CondutorEncontrado.CPF == condutor.CPF &&
                   CondutorEncontrado.Id != condutor.Id;
        }

        private bool NomeDuplicado(Condutor condutor)
        {
            var CondutorEncontrado = repositorioCondutor.SelecionarCondutorPorNome(condutor.Nome);

            return CondutorEncontrado != null &&
                   CondutorEncontrado.Nome == condutor.Nome &&
                   CondutorEncontrado.Id != condutor.Id;
        }

        private bool CNHDuplicada(Condutor condutor)
        {
            var CondutorEncontrado = repositorioCondutor.SelecionarCondutorPorCNH(condutor.CNH);

            return CondutorEncontrado != null &&
                   CondutorEncontrado.CNH == condutor.CNH &&
                   CondutorEncontrado.Id != condutor.Id;
        }
    }
}
