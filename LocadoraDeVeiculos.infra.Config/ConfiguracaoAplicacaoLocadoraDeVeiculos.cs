using Microsoft.Extensions.Configuration;
using System.IO;

namespace LocadoraDeVeiculos.infra.Config
{
    public class ConfiguracaoAplicacaoLocadoraDeVeiculos
    {
        public ConfiguracaoAplicacaoLocadoraDeVeiculos()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            var connectionstring = configuracao.GetConnectionString("sqlServer");

            ConnectionStrings = new ConnectionStrings { SqlServer = connectionstring };
            
            var diretoriosaida = configuracao.GetSection("ConfiguracaoLogs")
                .GetSection("DiretorioSaida")
                .Value;

            VersaoAplicacao = configuracao.GetSection("Versao").Value;

            ConfiguracaoLogs = new ConfiguracaoLogs { DiretorioSaida = diretoriosaida };

        }
        public string VersaoAplicacao { get; set; }
        public ConfiguracaoLogs ConfiguracaoLogs { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }


    }

    public class ConfiguracaoLogs
    {
        public string DiretorioSaida { get; set; }
    }
    public class ConnectionStrings
    {
        public string SqlServer { get; set; }
    }
}
