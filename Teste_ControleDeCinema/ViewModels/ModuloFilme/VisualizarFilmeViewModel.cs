using System;
using System.Collections.Generic;
using Teste_ControleDeCinema.Webapi.ViewModels.ModuloSessao;

namespace Teste_ControleDeCinema.Webapi.ViewModels.ModuloFilme
{
    public class VisualizarFilmeViewModel
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public TimeSpan Duracao { get; set; }

        public string Descricao { get; set; }

        public string UrlImagem { get; set; }

        public List<ListarSessaoViewModel> Sessoes { get; set; }
    }
}
