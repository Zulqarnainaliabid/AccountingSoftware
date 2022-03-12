using FluentValidation;
using Perfactcv.Api.Resources;

namespace Perfactcv.Api.Validations
{
    public class SaveCVBackupResourceValidator : AbstractValidator<SaveCVBackupResource>
    {
        public SaveCVBackupResourceValidator()
        {
            RuleFor(m => m.Subject)
                .NotEmpty()
                .MaximumLength(200);
            
            RuleFor(m => m.Data)
                .NotEmpty()
                .WithMessage("'Data' must not be 0.");

        }
    }
}