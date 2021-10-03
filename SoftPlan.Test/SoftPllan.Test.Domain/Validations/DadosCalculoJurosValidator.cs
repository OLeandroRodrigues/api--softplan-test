using FluentValidation;
using SoftPlan.Test.Domain.ViewModel;

namespace SoftPlan.Test.Domain.Validations
{
    public class DadosCalculoJurosValidator : AbstractValidator<DadosCalculoJurosViewModel>
    {
        public DadosCalculoJurosValidator()
        {
            RuleFor(x => x.ValorInicial)
                .NotNull()
                .WithMessage("O valor inicial precisa ser informado.")
                .GreaterThan(0).WithMessage("O valor inicial precisa ser maior que zero.");
            RuleFor(x => x.Meses)
                .NotNull()
                .WithMessage("A quantidade de meses precisa ser informado.")
                .GreaterThan(0).WithMessage("A quantidade de meses precisa ser informada."); ;

        }
    }
}
