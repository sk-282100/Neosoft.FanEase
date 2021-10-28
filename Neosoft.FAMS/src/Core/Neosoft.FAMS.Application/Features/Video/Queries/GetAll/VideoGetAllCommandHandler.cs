using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Video.Queries.GetAll
{
    class VideoGetAllCommandHandler : IRequestHandler<VideoGetAllCommand, List<VideoGetAllDto>>
    {
        private readonly IVideoRepository _videoRepo;
        private readonly IMapper _mapper;

        public VideoGetAllCommandHandler(IVideoRepository videoRepo, IMapper mapper)
        {
            _videoRepo = videoRepo;
            _mapper = mapper;
        }
        public async Task<List<VideoGetAllDto>> Handle(VideoGetAllCommand request, CancellationToken cancellationToken)
        {
            var data = await _videoRepo.ListAllAsync();
            var response = _mapper.Map<List<VideoGetAllDto>>(data);
            return response;
        }
    }
}
