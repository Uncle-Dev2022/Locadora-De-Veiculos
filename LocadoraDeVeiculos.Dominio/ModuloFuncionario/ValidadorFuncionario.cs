using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionário
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {

        public ValidadorFuncionario()
        {
            

            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Nome não pode ser nulo")
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .MinimumLength(2).WithMessage("Nome deve ter no mínimo 2 caracteres")
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$").WithMessage("Caracteres especiais não são permitidos!"); 
            

            RuleFor(x => x.Salario)
                .GreaterThan(0).WithMessage("Salario não pode ser menor que zero");

            RuleFor(x => x.DataAdmissao)
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Data de Admissão não pode ser Maior que hoje");

            RuleFor(x => x.Senha)
               .NotNull().WithMessage("Senha não pode ser nulo")
               .NotEmpty().WithMessage("Senha não pode ser vazio")
               .MinimumLength(2).WithMessage("Senha deve ter no mínimo 2 caracteres");

            RuleFor(x => x.Login)
               .NotNull().WithMessage("Login não pode ser nulo")
               .NotEmpty().WithMessage("Login não pode ser vazio")
               .MinimumLength(2).WithMessage("Login deve ter no mínimo 2 caracteres");

            

        }





    }
}
