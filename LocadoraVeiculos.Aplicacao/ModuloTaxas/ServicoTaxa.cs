using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.ModuloTaxas;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloTaxas
{
    public class ServicoTaxa
    {
        private IRepositorioTaxa repositorioTaxa;
        //private IContextoPersistencia contexto;
        public ServicoTaxa(IRepositorioTaxa repositorioTaxa /*,IContextoPresistencia contexto*/)
        {
            //this.contexto = contexto;
            this.repositorioTaxa = repositorioTaxa;
        }

        public Result<Taxa> Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir taxa... {@t}", taxa);

            Result resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir a taxa {taxaId} - {Motivo}",
                       taxa.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxa.Inserir(taxa);
                //contexto.GravarDados();
                Log.Logger.Information("taxa {taxaId} inserida com sucesso", taxa.Id);

                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a taxa";

                Log.Logger.Error(ex, msgErro + "{taxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxa> Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar taxa... {@t}", taxa);

            Result resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar a taxa {taxaId} - {Motivo}",
                       taxa.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxa.Editar(taxa);

                Log.Logger.Information("taxa {taxaId} editada com sucesso", taxa.Id);

                return Result.Ok(taxa);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a taxa";

                Log.Logger.Error(ex, msgErro + "{taxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando excluir taxa... {@t}", taxa);

            try
            {
                repositorioTaxa.Excluir(taxa);

                Log.Logger.Information("taxa {taxaId} excluída com sucesso", taxa.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir a taxa";

                Log.Logger.Error(ex, msgErro + "{taxaId}", taxa.Id);

                return Result.Fail(msgErro);
            }
        }
        private Result Validar(Taxa taxa)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(taxa);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors)//FluentValidation       
            {
                erros.Add(new Error(item.ErrorMessage));
            }


            if (DescricaoDuplicada(taxa))
                erros.Add(new Error("Nome Duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }
        public Result<List<Taxa>> SelecionarTodos()
        {

            try
            {
                return Result.Ok(repositorioTaxa.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar Selecionar todas as taxas";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }

        }
        public Result<Taxa> SelecionarPorId(Guid id)
        {

            try
            {
                return Result.Ok(repositorioTaxa.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar Selecionar a Taxa";

                Log.Logger.Error(ex, msgErro + "{taxaID}", id);

                return Result.Fail(msgErro);
            }

        }
        private bool DescricaoDuplicada(Taxa taxa)
        {
            var taxaEncontrada = repositorioTaxa.SelecionarPorDescricao(taxa.descricao);

            return taxaEncontrada != null &&
                   taxaEncontrada.descricao == taxa.descricao &&
                   taxaEncontrada.Id != taxa.Id;
        }
    }
}
