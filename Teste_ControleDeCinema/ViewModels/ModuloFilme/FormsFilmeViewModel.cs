using System;
using System.ComponentModel.DataAnnotations;

namespace Teste_ControleDeCinema.Webapi.ViewModels.ModuloFilme
{
    public class FormsFilmeViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public TimeSpan Duracao { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public string UrlImagem { get; set; }

    }
}
