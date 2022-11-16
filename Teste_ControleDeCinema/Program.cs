using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_ControleCinema.Infra.Logging;

namespace Teste_ControleDeCinema
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfiguracaoLogsControleCinema.ConfigurarEscritaLogs();

            Log.Logger.Information("Iniciando o servidor da aplicação Controle de Cinema...");

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception exc)
            {
                Log.Logger.Fatal(exc, "O servidor da aplicação Controle de Cinema parou inesperadamente.");

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
