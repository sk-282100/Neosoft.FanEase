using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Exceptions;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Viewer.Commands.Update
{
    public class UpdateViewerCommandHandler : IRequestHandler<UpdateViewerCommand, Response<bool>>
    {
        private readonly IViewerRepo _viewerRepo;
        private readonly IMapper _mapper;

        public UpdateViewerCommandHandler(IViewerRepo viewerRepo, IMapper mapper)
        {
            _viewerRepo = viewerRepo;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(UpdateViewerCommand request, CancellationToken cancellationToken)
        {
            //var eventToUpdate = await _viewerRepo.GetByIdAsync(request.ViewerId);
            var validator = new UpdateViewerByIdValidator(_viewerRepo);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var update = _mapper.Map<ViewerDetail>(request);
            await _viewerRepo.UpdateAsync(update);

            var response = new Response<bool> { Data = true, Message = "Updated Successfully", Succeeded = true };
            return response;
        }
    }
}
