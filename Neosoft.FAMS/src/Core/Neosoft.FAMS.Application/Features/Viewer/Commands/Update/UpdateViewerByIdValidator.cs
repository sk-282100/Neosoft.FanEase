using FluentValidation;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Viewer.Commands.Update
{
    public class UpdateViewerByIdValidator:AbstractValidator<UpdateViewerCommand>
    {
        private readonly IViewerRepo _viewerRepo;
        public UpdateViewerByIdValidator(IViewerRepo viewerRepo)
        {
            _viewerRepo = viewerRepo;
            RuleFor(p => p.FirstName)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.MiddleName)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.LastName)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.EmailId)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.MobileNumber)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Address1)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Address2)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.CountryId)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .GreaterThan(0).WithMessage("{PropertyName} must be Greater Than 0.");

            RuleFor(p => p.CityId)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .GreaterThan(0).WithMessage("{PropertyName} must be Greater Than 0.");
        }
    }
}
