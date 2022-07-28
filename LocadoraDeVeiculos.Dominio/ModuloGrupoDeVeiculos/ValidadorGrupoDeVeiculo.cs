using FluentValidation;
using System.Text.RegularExpressions;

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
