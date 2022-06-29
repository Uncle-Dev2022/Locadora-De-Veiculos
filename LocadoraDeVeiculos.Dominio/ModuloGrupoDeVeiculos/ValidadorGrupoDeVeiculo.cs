using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos
{
    public class ValidadorGrupoDeVeiculo : AbstractValidator<GrupoDeVeiculo>
    {
        public ValidadorGrupoDeVeiculo()
        {
            Regex padraoNome = new Regex("^[A-Z a-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ]*$");

            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Nome não pode ser nulo")
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .MinimumLength(2).WithMessage("Nome deve ter no mínimo 2 caracteres").Matches(padraoNome);
           
        }


    }
}
