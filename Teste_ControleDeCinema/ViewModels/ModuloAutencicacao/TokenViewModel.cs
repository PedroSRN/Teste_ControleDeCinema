using System;

namespace Teste_ControleDeCinema.Webapi.ViewModels.ModuloAutencicacao
{
    public class TokenViewModel
    {
        public string Chave { get; set; }

        public UsuarioTokenViewModel UsuarioToken { get; set; }

        public DateTime DataExpiracacao { get; set; }
    }
}
