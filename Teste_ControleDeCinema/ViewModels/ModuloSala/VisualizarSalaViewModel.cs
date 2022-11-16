using System;
using System.Collections.Generic;
using Teste_ControleDeCinema.Webapi.ViewModels.ModuloSessao;

namespace Teste_ControleDeCinema.Webapi.ViewModels.ModuloSala
{
    public class VisualizarSalaViewModel
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public int Capacidade { get; set; }

        public List<ListarSessaoViewModel> Sessoes { get; set; }
    }
}
