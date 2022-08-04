using Autofac;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionário;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.infra.Config;
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
using LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Orm.ModuloLocacao;
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
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxas;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;

namespace LocadoraDeVeiculos.WindowsFormApp.Compartilhado
{
    public class ServiceLocatorAutofac : IServiceLocator
    {
        private IContainer container;

        public ServiceLocatorAutofac()
        {
            var builder = new ContainerBuilder();

            var config = new ConfiguracaoAplicacaoLocadoraDeVeiculos();

            var connectionstring = config.ConnectionStrings.SqlServer;

            builder.RegisterType<LocadoraDeVeiculosDbContext>().As<IContextoPersistencia>()
                .InstancePerLifetimeScope()
                .WithParameter("connectionstring",connectionstring);

            //ok?
            builder.RegisterType<RepositorioGrupoDeVeiculosOrm>().As<IRepositorioGrupoDeVeiculo>();
            builder.RegisterType<ServicoGrupoDeVeiculo>().AsSelf();
            builder.RegisterType<ControladorGrupoDeVeiculo>().AsSelf();

            //ok?
            builder.RegisterType<RepositorioFuncionarioOrm>().As<IRepositorioFuncionario>();
            builder.RegisterType<ServicoFuncionario>().AsSelf();
            builder.RegisterType<ControladorFuncionario>().AsSelf();

            //Ok
            builder.RegisterType<RepositorioClienteOrm>().As<IRepositorioCliente>();
            builder.RegisterType<ServicoCliente>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();

            //ok?
            builder.RegisterType<RepositorioCondutorOrm>().As<IRepositorioCondutor>();
            builder.RegisterType<ServicoCondutor>().AsSelf();
            builder.RegisterType<ControladorCondutor>().AsSelf();

            //ok?
            builder.RegisterType<RepositorioTaxaOrm>().As<IRepositorioTaxa>();
            builder.RegisterType<ServicoTaxa>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();

            //ok?
            builder.RegisterType<RepositorioVeiculoOrm>().As<IRepositorioVeiculo>();
            builder.RegisterType<ServicoVeiculo>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();

            //ok?
            builder.RegisterType<RepositorioPlanoDeCobrancaOrm>().As<IRepositorioPlanoDeCobranca>();
            builder.RegisterType<ServicoPlanoDeCobranca>().AsSelf();
            builder.RegisterType<ControladorPlanoDeCobranca>().AsSelf();

            //locacao
            builder.RegisterType<RepositorioLocacaoOrm>().As<IRepositorioLocacao>();
            builder.RegisterType<ServicoLocacao>().AsSelf();
            builder.RegisterType<ControladorLocacao>().AsSelf();

            container = builder.Build();

        }


        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}
