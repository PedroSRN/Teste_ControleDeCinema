using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_ControleDeCinema.Dominio.Compartilhado;

namespace Teste_ControleDeCinema.Dominio.ModuloFilme
{
    public interface IRepositorioFilme : IRepositorio<Filme>
    {
        Filme SelecionarFilmePorNome(string titulo);
    }
}
