using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>
    {
        public ValidadorCondutor()
        {


            RuleFor(x => x.Nome).
                    NotNull().WithMessage("'Nome' NÃO pode estar vazio").
                    NotEmpty().WithMessage("'Nome' NÃO pode estar vazio");

            When(x => string.IsNullOrEmpty(x.Nome) == false, () =>
                {
                    RuleFor(x => x.Nome.Length)
                .GreaterThan(3)
                .WithMessage("O 'Nome' deve ter no minimo 4 caracteres");

                    RuleFor(x => x.Nome)
                .Matches(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]*$")
                .WithMessage("Caracteres especiais não são permitidos no campo 'Nome'");
                });

            RuleFor(x => x.Endereco).
                NotNull().WithMessage("'Endereco' NÃO pode estar vazio").
                NotEmpty().WithMessage("'Endereco' NÃO pode estar vazio");

            RuleFor(x => x.Email).
                    NotNull().WithMessage("'Email' NÃO pode estar vazio").
                    NotEmpty().WithMessage("'Email' NÃO pode estar vazio");

            RuleFor(x => x.Email)
                  .Custom((email, context) =>
                  {
                      if (string.IsNullOrEmpty(email) == false)
                      {
                          if (System.Net.Mail.MailAddress.TryCreate(email, out _) == false)
                              context.AddFailure("'Email' Inválido,Tente Novamente");
                      }
                  });

            RuleFor(x => x.CPF)
               .NotEmpty().WithMessage("'CPF' NÃO pode estar vazio")
               .NotNull().WithMessage("'CPF' NÃO pode estar vazio");

            RuleFor(x => x.CPF)
            .Custom((cpf, context) =>
            {
                if (Regex.IsMatch(cpf, @"^[0-9]{3}[\.][0-9]{3}[\.][0-9]{3}[\-][0-9]{2}", RegexOptions.IgnoreCase) == false)
                    context.AddFailure("'CPF' inválido, tente novamente");
            });

            RuleFor(x => x.CNH)
              .NotEmpty().WithMessage("'CNH' NÃO pode estar vazio")
              .NotNull().WithMessage("'CNH' NÃO pode estar vazio");

            RuleFor(x => x.CNH)
          .Custom((cnh, context) =>
          {
              if ((Regex.IsMatch(cnh, @"^[0-9]{11}")) == false)
                  context.AddFailure("'CNH' Inválida, tente novamente");

          });
        }
    }
}
