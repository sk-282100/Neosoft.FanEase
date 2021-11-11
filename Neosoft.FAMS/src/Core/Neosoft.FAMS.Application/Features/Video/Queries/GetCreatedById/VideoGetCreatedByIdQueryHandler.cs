using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Video.Queries.GetCreatedById
{
    public class VideoGetCreatedByIdQueryHandler : IRequestHandler<VideoGetCreatedByIdQuery, List<VideoGetAllDto>>
    {
        private readonly IVideoRepository _videoRepo;
        private readonly IMapper _mapper;

        public VideoGetCreatedByIdQueryHandler(IVideoRepository videoRepo, IMapper mapper)
        {
            _videoRepo = videoRepo;
            _mapper = mapper;
        }
        public async Task<List<VideoGetAllDto>> Handle(VideoGetCreatedByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _videoRepo.GetCreatedByIdAsync(request.CreatedById);
            var response = _mapper.Map<List<VideoGetAllDto>>(data);
            return response;
        }
    }
}
