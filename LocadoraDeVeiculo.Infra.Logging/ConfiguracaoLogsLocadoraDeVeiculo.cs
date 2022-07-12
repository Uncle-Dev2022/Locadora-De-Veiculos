using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace LocadoraDeVeiculo.Infra.Logging
{
    public class ConfiguracaoLogsLocadoraDeVeiculo
    {
        #region

        //criação do arquivo TXT de LOG 
        public static void ConfigurarEscritaLogs()
        {

            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();


            var diretoriosaida = configuracao.GetSection("ConfiguracaoLogs")
                .GetSection("DiretorioSaida")
                .Value;

            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Warning()
                         .WriteTo.File(diretoriosaida + "/log.txt",
                         rollingInterval: RollingInterval.Day,
                         outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                         .CreateLogger();

        }



        #endregion Criando arquivo LOG 

    }
}
