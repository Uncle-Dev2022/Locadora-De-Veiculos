using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private RepositorioCondutorEmBancoDeDados repositorioCondutor;

        public ServicoCondutor(RepositorioCondutorEmBancoDeDados repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public ValidationResult Inserir(Condutor condutor)
        {
            ValidationResult resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Inserir(condutor);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Condutor condutor)
        {
            ValidationResult resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Editar(condutor);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Condutor cliente)
        {
            var validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(cliente);

            return resultadoValidacao;
        }
    }
}
