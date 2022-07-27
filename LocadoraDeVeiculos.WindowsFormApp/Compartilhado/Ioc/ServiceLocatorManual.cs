using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloFuncionário;
using LocadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloTaxas;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using LocadoraDeVeiculos.LocadoraDeVeiculos.WindowsFormApp.Compartilhado.Ioc;
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
            var contextoDadosOrm = new LocadoraDeVeiculosDbContext();

            controladores = new Dictionary<string, ControladorBase>();

            var repositorioGrupoDeVeiculo = new RepositorioGrupoDeVeiculoEmBancoDeDados();
            var servicoGrupoVeiculo = new ServicoGrupoDeVeiculo(repositorioGrupoDeVeiculo);
            controladores.Add("ControladorGrupoDeVeiculo", new ControladorGrupoDeVeiculo(servicoGrupoVeiculo));

            var repositorioFuncionario = new RepositorioFuncionarioEmBancoDeDados();
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            controladores.Add("ControladorFuncionario", new ControladorFuncionario(servicoFuncionario));

            var repositorioCliente = new RepositorioClienteOrm(contextoDadosOrm);
            var servicoCliente = new ServicoCliente(repositorioCliente,contextoDadosOrm);
            controladores.Add("ControladorCliente", new ControladorCliente(servicoCliente));

            var repositorioCondutor = new RepositorioCondutorOrm(contextoDadosOrm);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor,contextoDadosOrm);
            controladores.Add("ControladorCondutor", new ControladorCondutor(servicoCondutor, servicoCliente));

            // foi mechido
            var repositorioTaxa = new RepositorioTaxaOrm(contextoDadosOrm);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa, contextoDadosOrm);
            controladores.Add("ControladorTaxa", new ControladorTaxa(servicoTaxa));

            var repositorioVeiculo = new RepositorioVeiculoEmBancoDeDados();
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo);
            controladores.Add("ControladorVeiculo", new ControladorVeiculo(servicoVeiculo, servicoGrupoVeiculo));

            var repositorioPlanoDeCobranca = new RepositorioPlanoDeCobrancaEmBancoDeDados();
            var servicoPlanoDeCobranca = new ServicoPlanoDeCobranca(repositorioPlanoDeCobranca);
            controladores.Add("ControladorPlanoDeCobranca", new ControladorPlanoDeCobranca(servicoPlanoDeCobranca, servicoGrupoVeiculo));

            /*
             * 
            var serializador = new SerializadorDadosEmJsonDotnet();

            var contextoDados = new GeradorTesteJsonContext(serializador);

            IConfiguration configuracao = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("ConfiguracaoAplicacao.json")
                 .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var contextoDadosOrm = new GeradorTesteDbContext(connectionString);

            //var repositorioDisciplina = new RepositorioDisciplinaEmArquivo(contextoDados);
            var repositorioDisciplina = new RepositorioDisciplinaOrm(contextoDadosOrm);            
            var servicoDisciplina = new ServicoDisciplina(repositorioDisciplina, contextoDadosOrm);
            controladores.Add("ControladorDisciplina", new ControladorDisciplina(servicoDisciplina));

            //var repositorioMateria = new RepositorioMateriaEmArquivo(contextoDados);
            var repositorioMateria = new RepositorioMateriaOrm(contextoDadosOrm);
            var servicoMateria = new ServicoMateria(repositorioMateria, contextoDadosOrm);
            controladores.Add("ControladorMateria", new ControladorMateria(servicoMateria, servicoDisciplina));

            //var repositorioQuestao = new RepositorioQuestaoEmArquivo(contextoDados);
            var repositorioQuestao = new RepositorioQuestaoOrm(contextoDadosOrm);
            var servicoQuestao = new ServicoQuestao(repositorioQuestao, contextoDadosOrm);
            controladores.Add("ControladorQuestao", new ControladorQuestao(servicoQuestao, servicoDisciplina));

            //var repositorioTeste = new RepositorioTesteEmArquivo(contextoDados);
            var repositorioTeste = new RepositorioTesteOrm(contextoDadosOrm);
            var servicoTeste = new ServicoTeste(repositorioTeste, contextoDadosOrm);
            controladores.Add("ControladorTeste", new ControladorTeste(servicoTeste, servicoDisciplina));

            controladores.Add("ControladorConfiguracao", new ControladorConfiguracao());
             
             * 
             */
        }
    }
}
