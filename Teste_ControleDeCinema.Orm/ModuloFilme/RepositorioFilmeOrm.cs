using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_ControleDeCinema.Dominio.Compartilhado;
using Teste_ControleDeCinema.Dominio.ModuloFilme;
using Teste_ControleDeCinema.Orm.Compartilhado;

namespace Teste_ControleDeCinema.Orm.ModuloFilme
{
    public class RepositorioFilmeOrm : RepositorioBase<Filme>, IRepositorioFilme
    {
       
        public RepositorioFilmeOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        public override Filme SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.Sessoes)
                .SingleOrDefault(x => x.Id == id);
        }

        
    }
}
