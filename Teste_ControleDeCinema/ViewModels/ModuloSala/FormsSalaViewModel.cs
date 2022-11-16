using System;
using System.ComponentModel.DataAnnotations;

namespace Teste_ControleDeCinema.Webapi.ViewModels.ModuloSala
{
    public class FormsSalaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
        public int Capacidade { get; set; }
    }
}
