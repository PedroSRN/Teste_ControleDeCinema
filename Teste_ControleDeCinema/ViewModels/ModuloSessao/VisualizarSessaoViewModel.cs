using System;
using Teste_ControleDeCinema.Dominio.ModuloSessao;
using Teste_ControleDeCinema.Webapi.ViewModels.ModuloFilme;
using Teste_ControleDeCinema.Webapi.ViewModels.ModuloSala;

namespace Teste_ControleDeCinema.Webapi.ViewModels.ModuloSessao
{
    public class VisualizarSessaoViewModel
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraTermino { get; set; }

        public string TipoSessao { get; set; }

        public string TipoAudio { get; set; }

        public decimal ValorIngresso { get; set; }

        public ListarFilmeViewModel Filme { get; set; }

        public ListarSalaViewModel Sala  { get; set; }
    }
}
