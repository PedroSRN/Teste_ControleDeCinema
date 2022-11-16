using Microsoft.EntityFrameworkCore;
using System.Linq;
using Teste_ControleDeCinema.Infra.Configs;

namespace Teste_ControleDeCinema.Orm.Compartilhado
{
    public static class MigradorBancoDadosControleCinema
    {
        public static bool AtualizarBancoDados(DbContext db)
        {
            var qtdMigracoesPendentes = db.Database.GetPendingMigrations().Count();

            if (qtdMigracoesPendentes == 0)
                return false;

            db.Database.Migrate();

            return true;
        }
    }
}
