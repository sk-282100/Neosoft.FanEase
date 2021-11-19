using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Neosoft.FAMS.Application.Contracts.Persistence;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetAll
{
    public class GetTopVideoQueryHandler : IRequestHandler<GetTopVideoQuery, List<GetTopVideoDto>>
    {
        private readonly IVideoPageRepository _videoPageRepository;
        private readonly IMapper _mapper;
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IContentCreatorRepo _contentCreatorRepo;
        private readonly IVideoRepository _videoRepository;

        public GetTopVideoQueryHandler(IMapper mapper, IVideoPageRepository videoPageRepository,
            IAdvertisementRepo advertisementRepo, IContentCreatorRepo contentCreatorRepo,
            IVideoRepository videoRepository)
        {
            _mapper = mapper;
            _videoPageRepository = videoPageRepository;
            _advertisementRepo = advertisementRepo;
            _contentCreatorRepo = contentCreatorRepo;
            _videoRepository = videoRepository;
        }

        public async Task<List<GetTopVideoDto>> Handle(GetTopVideoQuery request, CancellationToken cancellationToken)
        {
            List<GetTopVideoDto> result = new List<GetTopVideoDto>();
            var topVideos = _videoPageRepository.GetTopVideos();
            
            for (var i = 0; i < topVideos.Count; i++)
            {
                var detail = await _videoRepository.GetByIdAsync(topVideos[i]);
                if (detail != null)
                {
                    result.Add(new GetTopVideoDto()
                    {
                        topVideoId = topVideos[i],
                        UploadVideoPath = detail.UploadVideoPath,
                        Title = detail.Title,
                        topViews = await _videoPageRepository.GetViewsById(topVideos[i]),
                        topClicks = await _videoPageRepository.GetLikesById(topVideos[i]),
                        topShares=await _videoPageRepository.GetSharesById(topVideos[i]),
                        Decription = detail.Decription,
                        videoImage = detail.VideoImage
                    });
                }
                
            }

            return result.OrderByDescending(p=>p.topViews).ToList();

        }
    }
}

