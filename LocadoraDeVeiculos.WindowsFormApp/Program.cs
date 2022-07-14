
using LocadoraDeVeiculo.Infra.Logging;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WindowsFormApp
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfiguracaoLogsLocadoraDeVeiculo.ConfigurarEscritaLogs();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaPrincipalForm());
        }
    }
}
