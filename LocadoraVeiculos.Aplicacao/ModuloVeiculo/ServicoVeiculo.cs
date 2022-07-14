using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private IRepositorioVeiculo repositorioVeiculo;

        public ServicoVeiculo(IRepositorioVeiculo repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public ValidationResult Inserir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando inserir veiculo... {@v}", veiculo);
            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Inserir(veiculo);
                Log.Logger.Debug("Veiculo {VeiculoID} inserido com sucesso", veiculo.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Veiculo {VeiculoID} - {Motivo}",
                        veiculo.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar veiculo... {@v}", veiculo);
            ValidationResult resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Editar(veiculo);
                Log.Logger.Debug("Veiculo {VeiculoID} editado com sucesso", veiculo.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Veiculo {VeiculoID} - {Motivo}",
                        veiculo.Id, erro.ErrorMessage);
                }
            }


            return resultadoValidacao;
        }

        private ValidationResult Validar(Veiculo veiculo)
        {
            var validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            if (PlacaDuplicado(veiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Placa", "Placa duplicada"));

            return resultadoValidacao;
        }

        private bool PlacaDuplicado(Veiculo veiculo)
        {
            var funcionarioEncontrado = repositorioVeiculo.SelecionarVeiculoPorPlaca(veiculo.Placa);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Placa == veiculo.Placa &&
                   funcionarioEncontrado.Id != veiculo.Id;
        }

    }
}
