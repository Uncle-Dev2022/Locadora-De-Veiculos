using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
        public ValidadorTaxa(List<Taxa> taxas)
        {
            RuleFor(x => x.descricao).NotNull().WithMessage("A Descrição não pode ser nula")
            .When(x => x.descricao.Length < 2)
                .WithMessage("A Descrição não pode ser vazia ou possui menos que 2 caracteres")
            .When(x => Regex.IsMatch(@"^[a-zA-z\d\s]+$", x.descricao))
                .WithMessage("A Descrição deve conter letras e números apenas");

            RuleFor(x => x.valor).NotNull().WithMessage("O valor não pode ser nulo");

            RuleFor(x => x).Equal(x => taxas.Find(y => y.Equals(x)))
                .WithMessage("Não Pode inserir itens duplicados no banco");
        }
    }
}
