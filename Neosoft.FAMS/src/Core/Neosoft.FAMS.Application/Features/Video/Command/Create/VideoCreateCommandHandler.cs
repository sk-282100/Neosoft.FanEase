using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.Viewer.Commands.Create;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Video.Command.Create
{
    public class VideoCreateCommandHandler : IRequestHandler<VideoCreateCommand, Response<long>>
    {

        private readonly IVideoRepository _videoRepo;
        private readonly IMapper _mapper;
        public VideoCreateCommandHandler(IVideoRepository videoRepo, IMapper mapper)
        {
            _videoRepo = videoRepo;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(VideoCreateCommand request, CancellationToken cancellationToken)
        {
            //var data = await _videoRepo.AddAsync(_mapper.Map<VideoDetail>(request));
            //var response = new Response<long>(data.VideoId, "Inserted Successfully");
            //return response;

            var record = _mapper.Map<VideoDetail>(request);
            record.CreatedOn = DateTime.Now;
            record.CreatedBy = 2;
            record.IsDeleted = false;
            var data = await _videoRepo.AddAsync(record);
            var response = new Response<long>(data.VideoId, "Inserted successfully ");
            return response;

        }
    }
}