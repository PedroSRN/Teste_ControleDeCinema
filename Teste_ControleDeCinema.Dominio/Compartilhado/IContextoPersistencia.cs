using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_ControleDeCinema.Dominio.Compartilhado
{
    public interface  IContextoPersistencia
    {
        void DesfazerAlteracoes();

        void GravarDados();
    }
}
