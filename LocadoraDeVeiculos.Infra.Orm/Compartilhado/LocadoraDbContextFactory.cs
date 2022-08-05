using LocadoraDeVeiculos.infra.Config;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.Compartilhado
{
    public class LocadoraDbContextFactory : IDesignTimeDbContextFactory<LocadoraDeVeiculosDbContext>
    {
        public LocadoraDeVeiculosDbContext CreateDbContext(string[] args)
        {
            var config = new ConfiguracaoAplicacaoLocadoraDeVeiculos();
            return new LocadoraDeVeiculosDbContext(config.ConnectionStrings);
        }



    }
}
