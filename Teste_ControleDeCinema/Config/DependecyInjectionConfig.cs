using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teste_ControleDeCinema.Aplicacao.ModuloFilme;
using Teste_ControleDeCinema.Aplicacao.ModuloSala;
using Teste_ControleDeCinema.Aplicacao.ModuloSessao;
using Teste_ControleDeCinema.Dominio.Compartilhado;
using Teste_ControleDeCinema.Dominio.ModuloFilme;
using Teste_ControleDeCinema.Dominio.ModuloSala;
using Teste_ControleDeCinema.Dominio.ModuloSessao;
using Teste_ControleDeCinema.Infra.Configs;
using Teste_ControleDeCinema.Orm.Compartilhado;
using Teste_ControleDeCinema.Orm.ModuloFilme;
using Teste_ControleDeCinema.Orm.ModuloSala;
using Teste_ControleDeCinema.Orm.ModuloSessao;

namespace Teste_ControleDeCinema.Webapi.Config
{
    public static class DependecyInjectionConfig
    {
        public static void ConfigurarInjecaoDependencia(this IServiceCollection services)
        {
            services.AddSingleton((x) => new ConfiguracaoAplicacaoControleCinema().ConnectionStrings);

            services.AddScoped<ControleCinemaDbContext>();

            services.AddScoped<IContextoPersistencia, ControleCinemaDbContext>();

            services.AddScoped<IRepositorioFilme, RepositorioFilmeOrm>();
            services.AddTransient<ServicoFilme>();

            services.AddScoped<IRepositorioSala, RepositorioSalaOrm>();
            services.AddTransient<ServicoSala>();

            services.AddScoped<IRepositorioSessao, RepositorioSessaoOrm>();
            services.AddTransient<ServicoSessao>();

        }
    }
}
