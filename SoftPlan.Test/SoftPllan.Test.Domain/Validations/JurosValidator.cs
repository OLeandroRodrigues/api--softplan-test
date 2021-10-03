using FluentValidation;
using SoftPllan.Test.Domain.Entities;

namespace SoftPlan.Test.Domain.Validations
{
    public class JurosValidator : AbstractValidator<Juros>
    {
        public JurosValidator()
        {
            RuleFor(x => x.Taxa)
                .NotNull()
                .WithMessage("O valor da taxa precisa ser informado.")
                .GreaterThan(0).WithMessage("O valor da taxa precisa ser maior que zero.");
            
        }
    }
}
