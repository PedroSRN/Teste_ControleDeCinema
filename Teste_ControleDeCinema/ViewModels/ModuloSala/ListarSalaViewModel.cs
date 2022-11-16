using System;

namespace Teste_ControleDeCinema.Webapi.ViewModels.ModuloSala
{
    public class ListarSalaViewModel
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public int Capacidade { get; set; }
    }
}
