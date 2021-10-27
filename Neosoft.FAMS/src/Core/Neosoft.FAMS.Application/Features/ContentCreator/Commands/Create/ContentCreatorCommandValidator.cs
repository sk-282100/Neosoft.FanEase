using FluentValidation;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Commands.Create
{
    class ContentCreatorCommandValidator : AbstractValidator<ContentCreaterCommand>
    {
        private readonly IContentCreatorRepo _creatorRepo;
        public ContentCreatorCommandValidator(IContentCreatorRepo creatorRepo)
        {
            _creatorRepo = creatorRepo;

            RuleFor(p => p.CreatorName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.EmailId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            
            RuleFor(p => p.CountryId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greator than zero.");

            RuleFor(p => p.CityId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greator than zero.");

            RuleFor(p => p.MobileNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MinimumLength(10).WithMessage("{PropertyName} must contain 10 digits.")
               .MaximumLength(10).WithMessage("{PropertyName} must contain 10 digits.");
           
            RuleFor(p => p.Address1)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
