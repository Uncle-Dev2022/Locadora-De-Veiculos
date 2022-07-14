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
            RuleFor(x => x.grupoDeVeiculo).NotNull().WithMessage("O Grupo De Veículo não pode ser vazio / Nulo!");
            
            RuleFor(x => x.grupoDeVeiculo).Must((plano, grupoVeiculo, context) => {
                
                ValidadorGrupoDeVeiculo validador = new ValidadorGrupoDeVeiculo();
                ValidationResult resultado = validador.Validate(grupoVeiculo);
                List<ValidationFailure> erros = resultado.Errors;
                foreach (var item in erros)
                {
                    context.AddFailure(item);
                }
                return resultado.IsValid;                                
            });    
            


        }
    }
}
