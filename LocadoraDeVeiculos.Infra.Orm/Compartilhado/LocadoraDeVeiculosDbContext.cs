using LocadoraDeVeiculos.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LocadoraDeVeiculos.Infra.Orm.Compartilhado
{
    public class LocadoraDeVeiculosDbContext : DbContext, IContextoPersistencia
    {
        private string enderecoConexaoComBanco;
        public LocadoraDeVeiculosDbContext()
        {

        }

        public void GravarDados()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            enderecoConexaoComBanco = @"Data Source = (LocalDB)\MSSqlLocalDB; 
                Initial Catalog = LocadoraVeiculos.Db; 
                Integrated Security = True; 
                Pooling = False";
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
        }
    }
}
