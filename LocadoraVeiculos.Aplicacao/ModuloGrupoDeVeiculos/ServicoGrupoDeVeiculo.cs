using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionário;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using Serilog;

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
            Log.Logger.Debug("Tentando inserir grupo de veículo... {@g}", grupoDeVeiculo);
            ValidationResult resultadoValidacao = Validar(grupoDeVeiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioGrupoDeVeiculo.Inserir(grupoDeVeiculo);
                Log.Logger.Debug("Grupo de veículo {grupoVeiculoID} inserido com sucesso", grupoDeVeiculo.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um grupo de veículo {grupoVeiculoID} - {Motivo}",
                        grupoDeVeiculo.Id, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoDeVeiculo grupoDeVeiculo)
        {
            Log.Logger.Debug("Tentando editar grupo de veículo... {@g}", grupoDeVeiculo);
            ValidationResult resultadoValidacao = Validar(grupoDeVeiculo);

            if (resultadoValidacao.IsValid) { 
                repositorioGrupoDeVeiculo.Editar(grupoDeVeiculo);
                Log.Logger.Debug("Grupo de veículo {grupoVeiculoID} editado com sucesso", grupoDeVeiculo.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um grupo de veículo {grupoVeiculoID} - {Motivo}",
                        grupoDeVeiculo.Id, erro.ErrorMessage);
                }
            }
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
