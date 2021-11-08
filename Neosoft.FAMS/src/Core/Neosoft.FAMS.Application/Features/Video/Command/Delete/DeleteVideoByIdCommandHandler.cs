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
            var data = await _videoRepo.GetByIdAsync(request.VideoId);
            data.IsDeleted = true;
            if (data != null)
            {
                //await _videoRepo.DeleteAsync(data);
                await _videoRepo.UpdateAsync(data);
                var response = new Response<bool> { Data = true, Message = "Deleted Successfully", Succeeded = true };
                return response;
            }
            else
            {
                var response = new Response<bool> { Message = "No Data Found", Succeeded = true };
                return response;
            }
        }
    }
}
