using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.VideoPage.Commands.Update
{
    class UpdateVideoPageByIdCommandHandler : IRequestHandler<UpdateVideoPageByIdCommand, Response<bool>>
    {
        private readonly IVideoPageRepository _videoPageRepo;
        private readonly IMapper _mapper;
        public UpdateVideoPageByIdCommandHandler(IVideoPageRepository videoRepo, IMapper mapper)
        {
            _videoPageRepo = videoRepo;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(UpdateVideoPageByIdCommand request, CancellationToken cancellationToken)
        {
            var update = _mapper.Map<VideoStatisticsDetail>(request);
            await _videoPageRepo.UpdateAsync(update);

            var Response = new Response<bool> { Data = true, Message = "Updated Successfully", Succeeded = true };
            return Response;
        }
    }
}
