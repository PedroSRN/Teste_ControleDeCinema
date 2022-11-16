using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_ControleDeCinema.Dominio.ModuloFilme
{
    public class ValidadorFilme : AbstractValidator<Filme>
    {
        public ValidadorFilme()
        {
            RuleFor(x => x.Titulo)
                .NotNull().NotEmpty();

            RuleFor(x => x.Descricao)
                .NotNull().NotEmpty();

            RuleFor(x => x.Duracao)
                .NotEmpty();

            RuleFor(x => x.Imagem)
                .NotEmpty();

          
        }
    }
}
