using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_ControleDeCinema.Dominio.ModuloSala
{
    public class ValidadorSala : AbstractValidator<Sala>
    {
        public ValidadorSala()
        {
            RuleFor(x => x.Nome)
                .NotNull().NotEmpty();

            RuleFor(x => x.Capacidade)
                .GreaterThan(1)
                .NotNull()
                .NotEmpty();

        }
    }
}
