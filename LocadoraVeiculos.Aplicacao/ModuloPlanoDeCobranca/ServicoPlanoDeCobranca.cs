using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using Serilog;

namespace LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca
    {
        private IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;

        public ServicoPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioGrupoDeVeiuculo)
        {
            this.repositorioPlanoDeCobranca = repositorioGrupoDeVeiuculo;
        }

        public ValidationResult Inserir(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Tentando inserir Plano De Cobrança... {@p}", planoDeCobranca);

            ValidationResult resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
                Log.Logger.Debug("Plano De Cobrança {PlanoDeCobrancaID} inserido com sucesso", planoDeCobranca.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Plano De Cobrança {PlanoDeCobrancaID} - {Motivo}",
                        planoDeCobranca.Id, erro.ErrorMessage);
                }

            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Tentando editar Plano De Cobrança... {@p}", planoDeCobranca);

            ValidationResult resultadoValidacao = Validar(planoDeCobranca);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlanoDeCobranca.Editar(planoDeCobranca);
                Log.Logger.Debug("Plano De Cobrança {PlanoDeCobrancaID} editado com sucesso", planoDeCobranca.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Plano de Cobrança {PlanoDeCobrancaID} - {Motivo}",
                        planoDeCobranca.Id, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        private ValidationResult Validar(PlanoDeCobranca PlanoDeCobranca)
        {
            var validador = new ValidadorPlanoDeCobranca();

            var resultadoValidacao = validador.Validate(PlanoDeCobranca);

            if (NomeDuplicado(PlanoDeCobranca))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            return resultadoValidacao;
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
