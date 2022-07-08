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
        private IRepositorioCondutor repositorioCondutor;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor)
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

        private ValidationResult Validar(Condutor condutor)
        {
            var validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            if (NomeDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome Duplicado"));

            if(CPFDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF Duplicado"));

            if(CNHDuplicada(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("CNH", "CNH Duplicada"));


            return resultadoValidacao;
        }

        private bool CPFDuplicado(Condutor condutor)
        {
            var CondutorEncontrado = repositorioCondutor.SelecionarCondutorPorCPF(condutor.CPF);

            return CondutorEncontrado != null &&
                   CondutorEncontrado.CPF == condutor.CPF &&
                   CondutorEncontrado.Id != condutor.Id;
        }

        private bool NomeDuplicado(Condutor condutor)
        {
            var CondutorEncontrado = repositorioCondutor.SelecionarCondutorPorNome(condutor.Nome);

            return CondutorEncontrado != null &&
                   CondutorEncontrado.Nome == condutor.Nome &&
                   CondutorEncontrado.Id != condutor.Id;
        }

        private bool CNHDuplicada(Condutor condutor)
        {
            var CondutorEncontrado = repositorioCondutor.SelecionarCondutorPorCNH(condutor.CNH);

            return CondutorEncontrado != null &&
                   CondutorEncontrado.CNH == condutor.CNH &&
                   CondutorEncontrado.Id != condutor.Id;
        }
    }
}
