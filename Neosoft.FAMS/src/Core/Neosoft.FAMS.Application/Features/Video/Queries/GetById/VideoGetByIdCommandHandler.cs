using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Video.Queries.GetById
{
    public class VideoGetByIdCommandHandler : IRequestHandler<VideoGetByIdCommand, VideoGetAllDto>
    {
        private readonly IVideoRepository _videoRepo;
        private readonly IMapper _mapper;

        public VideoGetByIdCommandHandler(IVideoRepository videoRepo, IMapper mapper)
        {
            _videoRepo = videoRepo;
            _mapper = mapper;
        }
        public async Task<VideoGetAllDto> Handle(VideoGetByIdCommand request, CancellationToken cancellationToken)
        {
            var data = await _videoRepo.GetByIdAsync(request.VideoId);
            var response = _mapper.Map<VideoGetAllDto>(data);
            return response;

        }
    }
}
