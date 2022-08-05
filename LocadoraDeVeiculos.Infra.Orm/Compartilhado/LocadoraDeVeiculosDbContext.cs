using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.infra.Config;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Orm.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoDeCobrancaOrm;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.Orm.Compartilhado
{
    public class LocadoraDeVeiculosDbContext : DbContext, IContextoPersistencia
    {
        private string enderecoConexaoComBanco;
        public LocadoraDeVeiculosDbContext(ConnectionStrings connectionstring)
        {
            enderecoConexaoComBanco=connectionstring.SqlServer;
        }

        public void GravarDados()
        {
            SaveChanges();
        }
        public void DesfazerAlteracoes()
        {
            var registrosAlterados = ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged)
                .ToList();

            foreach (var registro in registrosAlterados)
            {
                switch (registro.State)
                {
                    case EntityState.Added:
                        registro.State = EntityState.Detached;
                        break;

                    case EntityState.Deleted:
                        registro.State = EntityState.Unchanged;
                        break;

                    case EntityState.Modified:
                        registro.State = EntityState.Unchanged;
                        registro.CurrentValues.SetValues(registro.OriginalValues);
                        break;

                    default:
                        break;
                }
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer(enderecoConexaoComBanco);
            ILoggerFactory loggerFactory = LoggerFactory.Create(x =>
            {
                // pacote Serilog.Extensions.Logging                
                x.AddSerilog(Log.Logger);
            });

            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dllComConfiguracoesOrm = typeof(LocadoraDeVeiculosDbContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(dllComConfiguracoesOrm);
            modelBuilder.ApplyConfiguration(new MapeadorPlanoDeCobrancaOrm());
            modelBuilder.ApplyConfiguration(new MapeadorTaxaOrm());
            modelBuilder.ApplyConfiguration(new MapeadorVeiculoOrm());
            modelBuilder.ApplyConfiguration(new MapeadorLocacaoOrm());
            modelBuilder.ApplyConfiguration(new MapeadorGrupoDeVeiculosOrm());
            modelBuilder.ApplyConfiguration(new MapeadorFuncionarioOrm());
            modelBuilder.ApplyConfiguration(new MapeadorCondutorOrm());
            modelBuilder.ApplyConfiguration(new MapeadorClienteOrm());
        }
    }
}
