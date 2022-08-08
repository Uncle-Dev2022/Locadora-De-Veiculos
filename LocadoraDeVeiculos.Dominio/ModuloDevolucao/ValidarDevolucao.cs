using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public class ValidarDevolucao : AbstractValidator<Devolucao>
    {
        public ValidarDevolucao()
        {
            RuleFor(x => x.QuilometragemDevolucao)
              .NotNull().WithMessage("Quilometragem de Devolucao não pode ser nulo")
              .NotEmpty().WithMessage("Quilometragem de Devolucao não pode ser vazio");

            RuleFor(x => x.DataDevolucao)
              .NotNull().WithMessage("Data de Devolucao não pode ser nulo")
              .NotEmpty().WithMessage("Data de Devolucao não pode ser vazio");

            RuleFor(x => x.NivelGasolina)
              .NotEmpty().WithMessage("Nivel de Gasolina de Devolucao não pode ser vazio");


        }
    }
}
