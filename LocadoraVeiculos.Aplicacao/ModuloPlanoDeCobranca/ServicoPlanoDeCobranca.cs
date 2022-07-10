using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;


namespace LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca
    {
        private IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;

        public ServicoPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioGrupoDeVeiuculo)
        {
            this.repositorioPlanoDeCobranca = repositorioGrupoDeVeiuculo;
        }

        public ValidationResult Inserir(PlanoDeCobranca PlanoDeCobranca)
        {
            ValidationResult resultadoValidacao = Validar(PlanoDeCobranca);

            if (resultadoValidacao.IsValid)
                repositorioPlanoDeCobranca.Inserir(PlanoDeCobranca);

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoDeCobranca PlanoDeCobranca)
        {
            ValidationResult resultadoValidacao = Validar(PlanoDeCobranca);

            if (resultadoValidacao.IsValid)
                repositorioPlanoDeCobranca.Editar(PlanoDeCobranca);

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
