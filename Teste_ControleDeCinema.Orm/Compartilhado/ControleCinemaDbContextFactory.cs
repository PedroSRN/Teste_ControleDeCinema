
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Teste_ControleDeCinema.Infra.Configs;

namespace Teste_ControleDeCinema.Orm.Compartilhado
{
    public class ControleCinemaDbContextFactory : IDesignTimeDbContextFactory<ControleCinemaDbContext>
    {
        public ControleCinemaDbContext CreateDbContext(string[] args)
        {
            var config = new ConfiguracaoAplicacaoControleCinema();

            return new ControleCinemaDbContext(config.ConnectionStrings);
        }

    }
}
