using FluentValidation;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.Video.Commands.Update;

namespace Neosoft.FAMS.Application.Features.Video.Command.Update
{
    class UpdateVideoByIdValidator : AbstractValidator<UpdateVideoByIdCommand>
    {
        private readonly IVideoRepository _videoRepo;
        public UpdateVideoByIdValidator(IVideoRepository videoRepo)
        {
            _videoRepo = videoRepo;

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.VideoImage)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.VideoId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
        }
    }
}
