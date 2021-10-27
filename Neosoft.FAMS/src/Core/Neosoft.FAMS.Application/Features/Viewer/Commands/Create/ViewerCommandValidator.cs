using FluentValidation;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Viewer.Commands.Create
{
    public class ViewerCommandValidator: AbstractValidator<ViewerCreateCommand>
    {
        private readonly IViewerRepo _viewerRepo;
        public ViewerCommandValidator(IViewerRepo viewerRepo)
        {
            _viewerRepo = viewerRepo;

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");


            RuleFor(p => p.MiddleName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.EmailId)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.MobileNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must not exceed 10 characters.");


            RuleFor(p => p.Address1)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");


            RuleFor(p => p.Address2)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 character.");

            RuleFor(p => p.CountryId)
                .GreaterThan(0).WithMessage("{PropertyName} must be grater than zero.");

            RuleFor(p => p.CityId)
                .GreaterThan(0).WithMessage("{PropertyName} must be grater than zero.");


        }
    }
}
