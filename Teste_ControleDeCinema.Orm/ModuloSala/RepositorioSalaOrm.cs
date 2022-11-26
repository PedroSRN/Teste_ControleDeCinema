using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_ControleDeCinema.Dominio.Compartilhado;
using Teste_ControleDeCinema.Dominio.ModuloSala;
using Teste_ControleDeCinema.Dominio.ModuloSessao;
using Teste_ControleDeCinema.Orm.Compartilhado;

namespace Teste_ControleDeCinema.Orm.ModuloSala
{
    public class RepositorioSalaOrm : RepositorioBase<Sala>, IRepositorioSala
    {
       
        public RepositorioSalaOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
          
        }

        public override Sala SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.Sessoes)
                .SingleOrDefault(x => x.Id == id);
        }

        //public List<Sala> SelecionarSalasDisponiveis(Sessao sessao)
        //{
        //    return registros
        //         .Include(x => x.Sessoes)
        //         .Where(x => x.Sessoes.Any(x => x.Data == sessao.Data))
        //         .Where(x => x.Sessoes.Any(x => x.HoraInicio < sessao.HoraInicio && x.HoraTermino > sessao.HoraTermino))
        //         .ToList();

        //}
    }
}
