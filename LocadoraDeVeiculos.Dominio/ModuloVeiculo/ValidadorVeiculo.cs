using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {
        public ValidadorVeiculo()
        {
            RuleFor(x => x.Marca)
               .NotNull().WithMessage("Marca não pode ser nulo")
               .NotEmpty().WithMessage("Marca não pode ser vazio");

            RuleFor(x => x.Modelo)
               .NotNull().WithMessage("Modelo não pode ser nulo")
               .NotEmpty().WithMessage("Modelo não pode ser vazio");

            RuleFor(x => x.Cor)
               .NotNull().WithMessage("Cor não pode ser nulo")
               .NotEmpty().WithMessage("Cor não pode ser vazio");

            RuleFor(x => x.AnoModelo)
               .NotNull().WithMessage("Ano Modelo não pode ser nulo")
               .NotEmpty().WithMessage("Ano Modelo não pode ser vazio");

            RuleFor(x => x.TipoCombustivel)
               .NotNull().WithMessage("Tipo Combustivel não pode ser nulo")
               .NotEmpty().WithMessage("Tipo Combustivel não pode ser vazio");

            RuleFor(x => x.Placa)
               .NotNull().WithMessage("Placa não pode ser nulo")
               .NotEmpty().WithMessage("Placa não pode ser vazio");

            RuleFor(x => x.Quilometragem)               
               .NotEmpty().WithMessage("Quilometragem não pode ser vazio");

            RuleFor(x => x.CapacidadeTanque)
               .NotEmpty().WithMessage("Capacidade Tanque não pode ser vazio");
            
            RuleFor(x => x.Imagem)
               .NotEmpty().WithMessage("Imagem não pode ser vazio");



        }
    }
}
