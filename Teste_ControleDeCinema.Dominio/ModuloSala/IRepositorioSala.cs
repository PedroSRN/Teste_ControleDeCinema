using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_ControleDeCinema.Dominio.Compartilhado;
using Teste_ControleDeCinema.Dominio.ModuloSessao;

namespace Teste_ControleDeCinema.Dominio.ModuloSala
{
    public interface IRepositorioSala : IRepositorio<Sala>
    {
        List<Sala> SelecionarSalasDisponiveis(Sessao sessao);
    }
}
