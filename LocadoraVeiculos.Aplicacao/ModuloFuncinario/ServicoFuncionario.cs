using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionário;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloFuncinario
{
    public class ServicoFuncionario
    {
        private IRepositorioFuncionario repositorioFuncionario;

        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public ValidationResult Inserir(GrupoDeVeiculo funcionario)
        {
            Log.Logger.Debug("Tentando inserir funcionário... {@f}", funcionario);
            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Inserir(funcionario);
                Log.Logger.Debug("Funcionário {FuncionarioID} inserido com sucesso", funcionario.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Funcionário {FuncionarioID} - {Motivo}",
                        funcionario.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoDeVeiculo funcionario)
        {
            Log.Logger.Debug("Tentando editar funcionário... {@f}", funcionario);
            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Editar(funcionario);
                Log.Logger.Debug("Funcionário {FuncionarioID} inserido com sucesso", funcionario.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Funcionário {FuncionarioID} - {Motivo}",
                        funcionario.Id, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(GrupoDeVeiculo funcionario)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(funcionario);

            if (NomeDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            if (LoginDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Login", "Login duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(GrupoDeVeiculo funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorNome(funcionario.Nome);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome == funcionario.Nome &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }

        private bool LoginDuplicado(GrupoDeVeiculo funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorLogin(funcionario.Login);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Login == funcionario.Login &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }




    }
}
