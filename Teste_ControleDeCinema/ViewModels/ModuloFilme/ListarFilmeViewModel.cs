using System;

namespace Teste_ControleDeCinema.Webapi.ViewModels.ModuloFilme
{
    public class ListarFilmeViewModel
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Duracao { get; set; }

        public string Descricao { get; set; }
    }
}
