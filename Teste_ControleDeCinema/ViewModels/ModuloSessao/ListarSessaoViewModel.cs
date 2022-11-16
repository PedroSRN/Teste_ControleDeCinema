using System;
using Teste_ControleDeCinema.Dominio.ModuloSessao;

namespace Teste_ControleDeCinema.Webapi.ViewModels.ModuloSessao
{
    public class ListarSessaoViewModel
    {
        public Guid Id { get; set; }

        public string Data { get; set; }

        public string HoraInicio { get; set; }

        public string HoraTermino { get; set; }

        public TipoSessaoEnum TipoSessao { get; set; }

        public TipoAudioEnum TipoAudio { get; set; }

        public string ValorIngresso { get; set; }

        public string NomeFilme { get; set; }

        public string NomeSala { get; set; }
    }
}
