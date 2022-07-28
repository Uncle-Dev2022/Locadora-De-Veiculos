using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxas
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {

        public ValidadorTaxa()
        {
            RuleFor(x => x.descricao).NotNull().WithMessage("A Descrição não pode ser nula");

            RuleFor(x => x.descricao).NotEmpty().WithMessage("A Descrição não pode ser vazia");

            RuleFor(x => x.descricao.Length)
                .GreaterThan(2).WithMessage("A Descrição não pode ser vazia ou possuir menos que 2 caracteres");

            RuleFor(x => x.descricao).Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$")
                .WithMessage("A Descrição não pode conter números ou símbolos especiais");
            RuleFor(x => x.valor).NotNull().WithMessage("O valor não pode ser nulo");

            RuleFor(x => x.tipoCalculo).NotNull().NotEmpty()
                .WithMessage("O tipo do Cálculo deve ser Diário ou Fixo");
        }
    }
}
