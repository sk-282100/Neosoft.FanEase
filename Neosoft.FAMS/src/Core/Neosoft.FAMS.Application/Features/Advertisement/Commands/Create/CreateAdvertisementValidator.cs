using FluentValidation;
using Neosoft.FAMS.Application.Contracts.Persistence;

namespace Neosoft.FAMS.Application.Features.Advertisement.Commands.Create
{
    class CreateAdvertisementValidator : AbstractValidator<CreateAdvertisementCommand>
    {
        private readonly IAdvertisementRepo _advertisementRepo;
        public CreateAdvertisementValidator(IAdvertisementRepo advertisementRepo)
        {
            _advertisementRepo = advertisementRepo;

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.ImagePath)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.VideoPath)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

        }
    }
}
