using FluentValidation;
using Neosoft.FAMS.Application.Contracts.Persistence;

namespace Neosoft.FAMS.Application.Features.Video.Command.Create
{
    public class VideoCreateCommandValidator : AbstractValidator<VideoCreateCommand>
    {
        private readonly IVideoRepository _videoRepo;
        public VideoCreateCommandValidator(IVideoRepository videoRepo)
        {
            _videoRepo = videoRepo;

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.VideoImage)
                .NotEmpty().WithMessage("{PropertyName} is required.");



            RuleFor(p => p.UploadVideoPath)
                .NotEmpty().WithMessage("{PropertyName} is required.");


        }
    }
}
