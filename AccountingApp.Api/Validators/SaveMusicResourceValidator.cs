using FluentValidation;
using AccountingApp.Api.Resources;

namespace AccountingApp.Api.Validations
{
    public class SaveLoanDetailResourceValidator : AbstractValidator<SaveLoanDetailResource>
    {
        public SaveLoanDetailResourceValidator()
        {
            RuleFor(m => m.Amount)
                .NotEmpty();
            
            RuleFor(m => m.LoanTakerId)
                .NotEmpty()
                .WithMessage("'LoanTaker Id' must not be 0.");
        }
    }
}