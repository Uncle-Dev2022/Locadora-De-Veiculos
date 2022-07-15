using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoDeCobranca : AbstractValidator<PlanoDeCobranca>
    {
        public ValidadorPlanoDeCobranca()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty()
                .WithMessage("O Nome do Plano não pode ser vazio / Nulo!")
            .Must(x => x.Length < 3)
                .WithMessage("O Nome do Plano não pode ter menos 3 caracteres!")
            .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$")
                .WithMessage("Caracteres especiais não são permitidos no campo 'Nome'");

            RuleFor(x => x.planoControlado).NotNull().NotEmpty()
                .WithMessage("O Plano Controlado não pode ser vazio / Nulo!")
            .Must(x => x.valorKm <= 0 && x.valorDiario <= 0 && x.limiteKm <= 0)
                .WithMessage("O Plano Controlado não pode conter planos que custam 0 ou menos / Limite De KM menor igual 0"); ;

            RuleFor(x => x.planoDiario).NotNull().NotEmpty()
                .WithMessage("O Plano Diário não pode ser vazio / Nulo!")
            .Must(x => x.valorKm <= 0 && x.valorDiario <= 0)
                .WithMessage("O Plano Diário não pode conter planos que custam 0 ou menos");

            RuleFor(x => x.planoLivre).NotNull().NotEmpty()
                .WithMessage("O Plano Livre não pode ser vazio / Nulo!")
            .Must(x => x.valorDiario <= 0)
                .WithMessage("O Plano Livre não pode conter planos que custam 0 ou menos");

            RuleFor(x => x.grupoDeVeiculo).NotNull().NotEmpty()
                .WithMessage("O Grupo De Veículo não pode ser vazio / Nulo!")
            .Must((plano, grupoVeiculo, context) => {
                
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
