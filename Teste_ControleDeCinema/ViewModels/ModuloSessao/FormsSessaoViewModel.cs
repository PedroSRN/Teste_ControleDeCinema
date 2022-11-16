using System;
using System.ComponentModel.DataAnnotations;
using Teste_ControleDeCinema.Dominio.ModuloSessao;

namespace Teste_ControleDeCinema.Webapi.ViewModels.ModuloSessao
{
    public class FormsSessaoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public TimeSpan HoraInicio { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public TimeSpan HoraTermino { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public TipoSessaoEnum TipoSessao { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public TipoAudioEnum TipoAudio { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public string ValorIngresso { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public Guid FilmeId { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public Guid SalaId { get; set; }

    }
}
