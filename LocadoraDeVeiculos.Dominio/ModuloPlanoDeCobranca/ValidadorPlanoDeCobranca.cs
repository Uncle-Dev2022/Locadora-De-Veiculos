using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoDeCobranca : AbstractValidator<PlanoDeCobranca>
    {
        public ValidadorPlanoDeCobranca()
        {
            RuleFor(x => x.Nome).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                    .WithMessage("O Nome do Plano não pode ser Nulo!")
                .NotEmpty()
                    .WithMessage("O Nome do Plano não pode ser Vazio!")
            .Must(x => x.Length > 2)
                .WithMessage("O Nome do Plano não pode ter menos de 3 caracteres!")

            .Matches(@"^[A-Za-záàâãéêíóôõúçÀÁÂÃÉÍÓÔÕÚÇ ]*$")
                .WithMessage("Caracteres especiais não são permitidos no campo 'Nome'");

            RuleFor(x => x.planoControlado).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                    .WithMessage("O Plano Controlado não pode ser Nulo!")
                .NotEmpty()
                    .WithMessage("O Plano Controlado não pode ser Vazio!")

            .Must(x => x.valorKm > 0 && x.valorDiario > 0 && x.limiteKm > 0)
                .WithMessage("O Plano Controlado não pode conter planos que custam 0 ou menos / Limite De KM menor igual 0");

            RuleFor(x => x.planoDiario).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                    .WithMessage("O Plano Diário não pode ser Nulo!")
                .NotEmpty()
                    .WithMessage("O Plano Diário não pode ser Vazio!")

            .Must(x => x.valorKm > 0 && x.valorDiario > 0)
                .WithMessage("O Plano Diário não pode conter planos que custam 0 ou menos");

            RuleFor(x => x.planoLivre).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                    .WithMessage("O Plano Livre não pode ser Nulo!")
                .NotEmpty()
                    .WithMessage("O Plano Livre não pode ser Vazio!")

            .Must(x => x.valorDiario > 0)
                .WithMessage("O Plano Livre não pode conter planos que custam 0 ou menos");

            RuleFor(x => x.grupoDeVeiculo).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                    .WithMessage("O Grupo De Veículo não pode ser Nulo!")
                .NotEmpty()
                    .WithMessage("O Grupo De Veículo não pode ser Vazio!")

            .Must((plano, grupoVeiculo, context) =>
            {

                ValidadorGrupoDeVeiculo validador = new ValidadorGrupoDeVeiculo();
                ValidationResult resultado = validador.Validate(grupoVeiculo);
                List<ValidationFailure> erros = resultado.Errors;
                foreach (var item in erros)
                {
                    context.AddFailure(item);
                }
                return resultado.IsValid;
            }).WithMessage("Resultado Da Validação Grupo De Veículo Falhou !");
        }
    }
}
