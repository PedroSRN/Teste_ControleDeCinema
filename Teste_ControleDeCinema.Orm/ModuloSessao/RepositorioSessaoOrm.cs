using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Teste_ControleDeCinema.Dominio.Compartilhado;
using Teste_ControleDeCinema.Dominio.ModuloSessao;
using Teste_ControleDeCinema.Orm.Compartilhado;

namespace Teste_ControleDeCinema.Orm.ModuloSessao
{
    public class RepositorioSessaoOrm : RepositorioBase<Sessao>, IRepositorioSessao
    {
        public RepositorioSessaoOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        public override Sessao SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.Filme)
                .Include(x => x.Sala)
                .SingleOrDefault(x => x.Id == id);

        }

        public override List<Sessao> SelecionarTodos(Guid usuarioId = new Guid())
        {
            return registros
                .Include(x => x.Filme)
                .Include(x => x.Sala)
                .Where(x => x.UsuarioId.Equals(usuarioId))
                .ToList();
        }
    }
}
