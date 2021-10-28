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

namespace Neosoft.FAMS.Application.Features.Video.Commands.Delete
{
    public class DeleteVideoByIdCommandHandler : IRequestHandler<DeleteVideoByIdCommand, Response<bool>>
    {
        private readonly IVideoRepository _videoRepo;
        private readonly IMapper _mapper;
        public DeleteVideoByIdCommandHandler(IVideoRepository videoRepo, IMapper mapper)
        {
            _videoRepo = videoRepo;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(DeleteVideoByIdCommand request, CancellationToken cancellationToken)
        {
            await _videoRepo.DeleteAsync(new VideoDetail { VideoId = request.VideoId });

            var response = new Response<bool> { Data = true, Message = "Deleted Successfully", Succeeded = true };
            return response;
        }


    }

}
