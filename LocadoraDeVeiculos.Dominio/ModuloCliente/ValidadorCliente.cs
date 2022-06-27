using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome).
                NotNull().WithMessage("Nome NÃO pode ser Nulo").
                NotEmpty().WithMessage("Nome NÃO pode ser Vazio");

            RuleFor(x => x.Endereco).
                NotNull().WithMessage("Endereco NÃO pode ser Nulo").
                NotEmpty().WithMessage("Endereco NÃO pode ser Vazio");

            RuleFor(x => x.Email).
                NotNull().WithMessage("Email NÃO pode ser Nulo").
                NotEmpty().WithMessage("Email NÃO pode ser Vazio");

            RuleFor(x => x.Telefone).
                NotNull().WithMessage("Telefone NÃO pode ser Nulo").
                NotEmpty().WithMessage("Telefone NÃO pode ser Vazio");

            //RuleFor(x => x.CNH).
               
        }

    }
}
