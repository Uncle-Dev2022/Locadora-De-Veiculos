using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionário;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;


namespace LocadoraVeiculos.Aplicacao.ModuloGrupoDeVeiculos
{
    public class ServicoGrupoDeVeiculo
    {

        private IRepositorioGrupoDeVeiculo repositorioGrupoDeVeiculo;

        public ServicoGrupoDeVeiculo(IRepositorioGrupoDeVeiculo repositorioGrupoDeVeiuculo)
        {
            this.repositorioGrupoDeVeiculo = repositorioGrupoDeVeiuculo;
        }

        public ValidationResult Inserir(GrupoDeVeiculo grupoDeVeiculo)
        {
            ValidationResult resultadoValidacao = Validar(grupoDeVeiculo);

            if (resultadoValidacao.IsValid)
                repositorioGrupoDeVeiculo.Inserir(grupoDeVeiculo);

            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoDeVeiculo grupoDeVeiculo)
        {
            ValidationResult resultadoValidacao = Validar(grupoDeVeiculo);

            if (resultadoValidacao.IsValid)
                repositorioGrupoDeVeiculo.Editar(grupoDeVeiculo);

            return resultadoValidacao;
        }

        private ValidationResult Validar(GrupoDeVeiculo grupoDeVeiculo)
        {
            var validador = new ValidadorGrupoDeVeiculo();

            var resultadoValidacao = validador.Validate(grupoDeVeiculo);

            if (NomeDuplicado(grupoDeVeiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));            

            return resultadoValidacao;
        }

        private bool NomeDuplicado(GrupoDeVeiculo grupoDeVeiculo)
        {
            var GrupoDeVeiculoEncontrado = repositorioGrupoDeVeiculo.SelecionarGrupoDeVeiculoPorNome(grupoDeVeiculo.Nome);

            return GrupoDeVeiculoEncontrado != null &&
                   GrupoDeVeiculoEncontrado.Nome == grupoDeVeiculo.Nome &&
                   GrupoDeVeiculoEncontrado.Id != grupoDeVeiculo.Id;
        }


    }
}
