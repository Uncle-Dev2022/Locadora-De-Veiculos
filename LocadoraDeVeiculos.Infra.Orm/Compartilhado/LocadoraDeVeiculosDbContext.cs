using LocadoraDeVeiculos.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;

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
            //optionsBuilder.LogTo(Console.WriteLine);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
