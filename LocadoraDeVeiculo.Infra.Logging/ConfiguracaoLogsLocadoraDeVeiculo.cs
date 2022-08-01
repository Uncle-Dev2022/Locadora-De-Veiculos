using LocadoraDeVeiculos.infra.Config;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.IO;

namespace LocadoraDeVeiculo.Infra.Logging
{
    public class ConfiguracaoLogsLocadoraDeVeiculo
    {
        #region

        //criação do arquivo TXT de LOG 
        public static void ConfigurarEscritaLogs()
        {
            var config = new ConfiguracaoAplicacaoLocadoraDeVeiculos();

            var diretoriosaida = config.ConfiguracaoLogs.DiretorioSaida;

            /*             
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Warning()
                         .WriteTo.File(diretoriosaida + "/log.txt",
                         rollingInterval: RollingInterval.Day,
                         outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                         .CreateLogger(); */
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Debug()
                    .WriteTo.Seq("http://localhost:5341")
                    .WriteTo.File(diretoriosaida + "/log.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:dd-MM-yyyy HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                    .CreateLogger();
        }



        #endregion Criando arquivo LOG 

    }
}
