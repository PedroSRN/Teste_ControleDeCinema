using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_ControleCinema.Infra.Logging;
using Teste_ControleDeCinema.Orm.Compartilhado;

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
                var app = CreateHostBuilder(args).Build();

                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    var db = services.GetRequiredService<ControleCinemaDbContext>();

                    Log.Logger.Information("Atualizando a banco de dados do Controle de Cinema...");

                    var migracaoRealizada = MigradorBancoDadosControleCinema.AtualizarBancoDados(db);

                    if (migracaoRealizada)
                        Log.Logger.Information("Banco de dados atualizado");
                    else
                        Log.Logger.Information("Nenhuma migração pendente");
                }

                Log.Logger.Information("Iniciando o servidor da aplicação Controle de Cinema...");

                app.Run();
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
