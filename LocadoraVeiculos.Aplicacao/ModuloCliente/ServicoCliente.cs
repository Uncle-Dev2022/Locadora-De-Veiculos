using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private RepositorioClienteEmBancoDeDados repositorioCliente;

        public ServicoCliente(RepositorioClienteEmBancoDeDados repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente cliente)
        {
            ValidationResult resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Inserir(cliente);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente cliente)
        {
            ValidationResult resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Editar(cliente);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Cliente cliente)
        {
            ValidationResult resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Excluir(cliente);

            return resultadoValidacao;
        }

        private ValidationResult Validar(Cliente cliente)
        {
            var validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(cliente);

            if (NomeDuplicado(cliente))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome Duplicado"));

            if(CPF_CNPJDuplicado(cliente))
            {
                if(cliente.tipoCliente==true)
                    resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF Duplicado"));
                else
                    resultadoValidacao.Errors.Add(new ValidationFailure("CNPJ", "CNPJ Duplicado"));
            }
                

            return resultadoValidacao;
        }

        private bool CPF_CNPJDuplicado(Cliente cliente)
        {
            var ClienteEncontrado = repositorioCliente.SelecionarClientePorNome(cliente.CPF_CNPJ);

            return ClienteEncontrado != null &&
                   ClienteEncontrado.CPF_CNPJ == cliente.CPF_CNPJ &&
                   ClienteEncontrado.Id != cliente.Id;
        }

        private bool NomeDuplicado(Cliente cliente)
        {
            var ClienteEncontrado = repositorioCliente.SelecionarClientePorNome(cliente.Nome);

            return ClienteEncontrado != null &&
                   ClienteEncontrado.Nome==cliente.Nome &&
                   ClienteEncontrado.Id != cliente.Id;
        }
    }
}
