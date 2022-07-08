using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.ModuloTaxas;
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

        public ValidationResult Inserir(Taxa Taxa)
        {
            ValidationResult resultadoValidacao = Validar(Taxa);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Inserir(Taxa);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa Taxa)
        {
            ValidationResult resultadoValidacao = Validar(Taxa);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Editar(Taxa);

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
