using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_ControleDeCinema.Infra.Configs;

namespace Teste_ControleCinema.Infra.Logging
{
    public class ConfiguracaoLogsControleCinema
    {
        public static void ConfigurarEscritaLogs()
        {
            var config = new ConfiguracaoAplicacaoControleCinema();

            var diretorioSaida = config.ConfiguracaoLogs.DiretorioSaida;

            Log.Logger = new LoggerConfiguration()
                   .MinimumLevel.Override("Microsoft", LogEventLevel.Information).Enrich.FromLogContext()
                   .MinimumLevel.Debug()
                   .WriteTo.Console()
                   .CreateLogger();

        }
    }
}
