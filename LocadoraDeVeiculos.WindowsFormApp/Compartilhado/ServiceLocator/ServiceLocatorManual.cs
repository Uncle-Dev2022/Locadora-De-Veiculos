using LocadoraDeVeiculos.infra.Config;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoDeCobrancaOrm;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
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
using System.Collections.Generic;

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
            var config = new ConfiguracaoAplicacaoLocadoraDeVeiculos();

            var connectionstring = config.ConnectionStrings.SqlServer;

            var contextoDadosOrm = new LocadoraDeVeiculosDbContext(connectionstring);
            controladores = new Dictionary<string, ControladorBase>();

            var repositorioGrupoDeVeiculo = new RepositorioGrupoDeVeiculosOrm(contextoDadosOrm);
            var servicoGrupoVeiculo = new ServicoGrupoDeVeiculo(repositorioGrupoDeVeiculo);
            controladores.Add("ControladorGrupoDeVeiculo", new ControladorGrupoDeVeiculo(servicoGrupoVeiculo));

            var repositorioFuncionario = new RepositorioFuncionarioOrm(contextoDadosOrm);
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            controladores.Add("ControladorFuncionario", new ControladorFuncionario(servicoFuncionario));

            var repositorioCliente = new RepositorioClienteOrm(contextoDadosOrm);
            var servicoCliente = new ServicoCliente(repositorioCliente);
            controladores.Add("ControladorCliente", new ControladorCliente(servicoCliente));

            var repositorioCondutor = new RepositorioCondutorOrm(contextoDadosOrm);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor);
            controladores.Add("ControladorCondutor", new ControladorCondutor(servicoCondutor, servicoCliente));

            // foi mechido
            var repositorioTaxa = new RepositorioTaxaOrm(contextoDadosOrm);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa);
            controladores.Add("ControladorTaxa", new ControladorTaxa(servicoTaxa));

            var repositorioVeiculo = new RepositorioVeiculoOrm(contextoDadosOrm);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo);
            controladores.Add("ControladorVeiculo", new ControladorVeiculo(servicoVeiculo, servicoGrupoVeiculo));

            var repositorioPlanoDeCobranca = new RepositorioPlanoDeCobrancaOrm(contextoDadosOrm);
            var servicoPlanoDeCobranca = new ServicoPlanoDeCobranca(repositorioPlanoDeCobranca);
            controladores.Add("ControladorPlanoDeCobranca", new ControladorPlanoDeCobranca(servicoPlanoDeCobranca, servicoGrupoVeiculo));
        }
    }
}
