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

namespace Neosoft.FAMS.Application.Features.Video.Commands.Update
{
    public class UpdateVideoByIdCommandHandler : IRequestHandler<UpdateVideoByIdCommand, Response<bool>>
    {
        private readonly IVideoRepository _videoRepo;
        private readonly IMapper _mapper;
        public UpdateVideoByIdCommandHandler(IVideoRepository videoRepo, IMapper mapper)
        {
            _videoRepo = videoRepo;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(UpdateVideoByIdCommand request, CancellationToken cancellationToken)
        {

            var update = _mapper.Map<VideoDetail>(request);
            await _videoRepo.UpdateAsync(update);

            var Response = new Response<bool> { Data = true, Message = "Updated Successfully", Succeeded = true };
            return Response;


        }
    }
}