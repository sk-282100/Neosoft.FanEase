using FluentValidation;
using Neosoft.FAMS.Application.Contracts.Persistence;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Commands.Update
{
    class UpdateCreatorByIdvalidator : AbstractValidator<UpdateCreatorByIdCommand>
    {
        private readonly IContentCreatorRepo _creatorRepo;
        public UpdateCreatorByIdvalidator(IContentCreatorRepo creatorRepo)
        {
            _creatorRepo = creatorRepo;

            RuleFor(p => p.CreatorName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Address1)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.EmailId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.MobileNumber)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(10).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(p => p.CityId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

            RuleFor(p => p.CountryId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
        }


    }
}

