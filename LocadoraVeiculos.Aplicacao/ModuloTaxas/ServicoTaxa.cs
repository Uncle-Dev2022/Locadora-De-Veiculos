using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.ModuloTaxas;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloTaxas
{
    public class ServicoTaxa
    {
        private RepositorioTaxaEmBancoDeDados repositorioTaxa;

        public ServicoTaxa(RepositorioTaxaEmBancoDeDados repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public ValidationResult Inserir(Taxa taxa)
        {
            Log.Logger.Debug("Tentando inserir Taxa... {@t}", taxa);

            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Inserir(taxa);
                Log.Logger.Debug("Taxa {TaxaDescricao} inserida com sucesso", taxa.descricao);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir uma Taxa{TaxaDescricao} - {Motivo}",
                        taxa.descricao, erro.ErrorMessage);
                }

            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa taxa)
        {
            Log.Logger.Debug("Tentando editar Taxa... {@t}", taxa);

            ValidationResult resultadoValidacao = Validar(taxa);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Editar(taxa);
                Log.Logger.Debug("Taxa {TaxaDescricao} editada com sucesso", taxa.descricao);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar uma Taxa {TaxaDescricao} - {Motivo}",
                        taxa.descricao, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }
        private ValidationResult Validar(Taxa Taxa)
        {
            var validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(Taxa);

            if (DescricaoDuplicada(Taxa))
                resultadoValidacao.Errors.Add(new ValidationFailure("Descrição", "Descrição Duplicada"));

            return resultadoValidacao;
        }

        private bool DescricaoDuplicada(Taxa taxa)
        {
            var taxaEncontrada = repositorioTaxa.SelecionarPorId(taxa.Id);

            return taxaEncontrada != null &&
                   taxaEncontrada.descricao == taxa.descricao &&
                   taxaEncontrada.Id != taxa.Id;
        }
    }
}
