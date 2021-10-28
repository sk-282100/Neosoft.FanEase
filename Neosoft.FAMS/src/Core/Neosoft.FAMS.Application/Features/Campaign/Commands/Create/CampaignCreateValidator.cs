using FluentValidation;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Campaign.Commands.Create
{
    class CampaignCreateValidator : AbstractValidator<CampaignCreateCommand>
    {
        private readonly ICampaignDetailRepo _campaignDetailRepo;
        public CampaignCreateValidator(ICampaignDetailRepo campaignDetailRepo)
        {
            _campaignDetailRepo = campaignDetailRepo;

            RuleFor(p => p.CampaignName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.EndDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

        }
    }
}
