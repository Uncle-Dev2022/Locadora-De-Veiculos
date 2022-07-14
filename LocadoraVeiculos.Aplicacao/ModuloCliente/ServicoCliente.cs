using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCliente;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private IRepositorioCliente repositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente cliente)
        {
            Log.Logger.Debug("Tentando inserir Cliente... {@c}", cliente);
            ValidationResult resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Inserir(cliente);
                Log.Logger.Debug("Cliente {clienteID} inserido com sucesso", cliente.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um cliente {clienteID} - {Motivo}",
                        cliente.Id, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente cliente)
        {
            Log.Logger.Debug("Tentando editar cliente... {@c}", cliente);
            ValidationResult resultadoValidacao = Validar(cliente);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Editar(cliente);
                Log.Logger.Debug("cliente {clienteID} editado com sucesso", cliente.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um cliente {clienteID} - {Motivo}",
                        cliente.Id, erro.ErrorMessage);
                }
            }
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
            var ClienteEncontrado = repositorioCliente.SelecionarClientePorCPFOuCNPJ(cliente.CPF_CNPJ);

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
