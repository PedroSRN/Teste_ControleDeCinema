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

        public TipoSessaoEnum TipoSessao { get; set; }

        public TipoAudioEnum TipoAudio { get; set; }

        public string ValorIngresso { get; set; }

        public ListarFilmeViewModel Filme { get; set; }

        public ListarSalaViewModel Sala  { get; set; }
    }
}
