using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloFuncionário;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloTaxas;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.WindowsFormApp.ModuloCliente;
using LocadoraDeVeiculos.WindowsFormApp.ModuloCondutor;
using LocadoraDeVeiculos.WindowsFormApp.ModuloFuncionário;
using LocadoraDeVeiculos.WindowsFormApp.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WindowsFormApp.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WindowsFormApp.ModuloTaxas;
using LocadoraDeVeiculos.WindowsFormApp.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloFuncinario;
using LocadoraVeiculos.Aplicacao.ModuloGrupoDeVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxas;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsFormApp.Compartilhado
{
    public class ServiceLocatorManual : IServiceLocator
    {
        private Dictionary<string, ControladorBase> controladores;
        public ServiceLocatorManual()
        {
            InicializarControladores();
        }

        public T Get<T>() where T : ControladorBase
        {
            var tipo = typeof(T);

            var nomeControlador = tipo.Name;

            return (T)controladores[nomeControlador];
        }

        private void InicializarControladores()
        {
            controladores = new Dictionary<string, ControladorBase>();

            var repositorioGrupoDeVeiculo = new RepositorioGrupoDeVeiculoEmBancoDeDados();
            var servicoGrupoVeiculo = new ServicoGrupoDeVeiculo(repositorioGrupoDeVeiculo);
            controladores.Add("ControladorGrupoDeVeiculo", new ControladorGrupoDeVeiculo(servicoGrupoVeiculo));

            var repositorioFuncionario = new RepositorioFuncionarioEmBancoDeDados();
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            controladores.Add("ControladorFuncionario", new ControladorFuncionario(servicoFuncionario));

            var repositorioCliente = new RepositorioClienteEmBancoDeDados();
            var servicoCliente = new ServicoCliente(repositorioCliente);
            controladores.Add("ControladorCliente", new ControladorCliente(servicoCliente));

            var repositorioCondutor = new RepositorioCondutorEmBancoDeDados();
            var servicoCondutor = new ServicoCondutor(repositorioCondutor);
            controladores.Add("ControladorCondutor", new ControladorCondutor(servicoCondutor, servicoCliente));

            var repositorioTaxa = new RepositorioTaxaEmBancoDeDados();
            var servicoTaxa = new ServicoTaxa(repositorioTaxa);
            controladores.Add("ControladorTaxa", new ControladorTaxa(servicoTaxa));

            var repositorioVeiculo = new RepositorioVeiculoEmBancoDeDados();
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo);
            controladores.Add("ControladorVeiculo", new ControladorVeiculo(servicoVeiculo, servicoGrupoVeiculo));

            var repositorioPlanoDeCobranca = new RepositorioPlanoDeCobrancaEmBancoDeDados();
            var servicoPlanoDeCobranca = new ServicoPlanoDeCobranca(repositorioPlanoDeCobranca);
            controladores.Add("ControladorPlanoDeCobranca", new ControladorPlanoDeCobranca(servicoPlanoDeCobranca, servicoGrupoVeiculo));
        }
    }
}
