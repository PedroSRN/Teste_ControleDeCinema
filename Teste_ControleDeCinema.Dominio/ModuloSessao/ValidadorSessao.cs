using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_ControleDeCinema.Dominio.ModuloSessao
{
    public class ValidadorSessao : AbstractValidator<Sessao>
    {
        public ValidadorSessao()
        {
            RuleFor(x => x.Data)
                .GreaterThanOrEqualTo((x) => DateTime.Now.Date).WithMessage("A data deve ser superior ou igual a data atual.")
                .NotEmpty();

            RuleFor(x => x.HoraInicio)
                .NotEmpty();

            RuleFor(x => x.ValorIngresso)
                .GreaterThan(1)
                .NotEmpty();

            RuleFor(x => x.FilmeId)
                .NotNull()
                .NotEmpty();
               
            RuleFor(x => x.SalaId)
                .NotNull()
                .NotEmpty();


           
        }
    }
}
