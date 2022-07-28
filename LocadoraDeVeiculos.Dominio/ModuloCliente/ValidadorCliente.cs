using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
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

            RuleFor(x => x.Telefone).
                NotNull().WithMessage("'Telefone' NÃO pode estar vazio").
                NotEmpty().WithMessage("'Telefone' NÃO pode estar vazio");

            RuleFor(x => x.Telefone)
             .Custom((telefone, context) =>
             {
                 if (string.IsNullOrEmpty(telefone) == false)
                 {
                     if ((Regex.IsMatch(telefone, @"^\([0-9]{2}\) [0-9]{5}\-[0-9]{4}$")) == false)
                         context.AddFailure("'Telefone' Inválido, tente novamente");
                 }
             });

            When(x => x.tipoCliente == true, () =>
            {
                RuleFor(x => x.CPF_CNPJ)
                .NotEmpty().WithMessage("'CPF' NÃO pode estar vazio")
                .NotNull().WithMessage("'CPF' NÃO pode estar vazio");

                RuleFor(x => x.CPF_CNPJ)
                .Custom((cpf, context) =>
                {
                    if (string.IsNullOrEmpty(cpf) == false)
                    {
                        if (Regex.IsMatch(cpf, @"^[0-9]{3}[\.][0-9]{3}[\.][0-9]{3}[\-][0-9]{2}", RegexOptions.IgnoreCase) == false)
                            context.AddFailure("'CPF' inválido, tente novamente");
                    }
                });

                RuleFor(x => x.CNH)
               .NotEmpty().WithMessage("'CNH' NÃO pode estar vazio")
               .NotNull().WithMessage("'CNH' NÃO pode estar vazio");

                RuleFor(x => x.CNH)
              .Custom((cnh, context) =>
              {
                  if (string.IsNullOrEmpty(cnh) == false)
                  {
                      if ((Regex.IsMatch(cnh, @"^[0-9]{11}")) == false)
                          context.AddFailure("'CNH' Inválida, tente novamente");
                  }
              });
            });

            When(x => x.tipoCliente == false, () =>
            {
                RuleFor(x => x.CPF_CNPJ)
                .NotEmpty().WithMessage("'CNPJ' NÃO pode estar vazio")
                .NotNull().WithMessage("'CNPJ' NÃO pode estar vazio");

                RuleFor(x => x.CPF_CNPJ)
                .Custom((cnpj, context) =>
                {
                    if (string.IsNullOrEmpty(cnpj) == false)
                    {
                        if (Regex.IsMatch(cnpj, @"^[0-9]{2}[\.][0-9]{3}[\.][0-9]{3}[\/][0-9]{4}[-][0-9]{2}", RegexOptions.IgnoreCase) == false)
                            context.AddFailure("'CNPJ' inválido, tente novamente");
                    }
                });
            });
        }
    }

}

