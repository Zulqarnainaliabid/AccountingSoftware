using FluentValidation;
using AccountingApp.Api.Resources;

namespace AccountingApp.Api.Validations
{
    public class SaveLoanTakerResourceValidator : AbstractValidator<SaveLoanTakerResource>
    {
        public SaveLoanTakerResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);

        }
    }
}