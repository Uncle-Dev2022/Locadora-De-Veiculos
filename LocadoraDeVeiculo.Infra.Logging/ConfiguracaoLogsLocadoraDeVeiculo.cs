using Serilog;
using System;

namespace LocadoraDeVeiculo.Infra.Logging
{
    public class ConfiguracaoLogsLocadoraDeVeiculo
    {
        #region

        //criação do arquivo TXT de LOG 
        public static void ConfigurarEscritaLogs()
        {
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Warning()
                         .WriteTo.File("logs/log.txt",
                         rollingInterval: RollingInterval.Day,
                         outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                         .CreateLogger();

        }



        #endregion Criando arquivo LOG 

    }
}
