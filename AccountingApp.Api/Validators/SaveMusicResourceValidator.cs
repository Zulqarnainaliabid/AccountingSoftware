using FluentValidation;
using Perfactcv.Api.Resources;

namespace Perfactcv.Api.Validations
{
    public class SaveMusicResourceValidator : AbstractValidator<SaveMusicResource>
    {
        public SaveMusicResourceValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);
            
            RuleFor(m => m.ArtistId)
                .NotEmpty()
                .WithMessage("'Artist Id' must not be 0.");
        }
    }
}