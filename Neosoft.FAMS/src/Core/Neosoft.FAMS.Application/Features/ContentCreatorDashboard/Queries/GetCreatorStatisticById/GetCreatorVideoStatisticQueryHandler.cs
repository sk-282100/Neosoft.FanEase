using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.GetCreatorStatisticById
{
    public class GetCreatorVideoStatisticQueryHandler : IRequestHandler<GetCreatorVideoStatisticQuery, List<long>>
    {
        private readonly IVideoPageRepository _videoPageRepository;
        private readonly IMapper _mapper;
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IContentCreatorRepo _contentCreatorRepo;
        private readonly IVideoRepository _videoRepository;

        public GetCreatorVideoStatisticQueryHandler(IMapper mapper, IVideoPageRepository videoPageRepository, IAdvertisementRepo advertisementRepo, IContentCreatorRepo contentCreatorRepo, IVideoRepository videoRepository)
        {
            _mapper = mapper;
            _videoPageRepository = videoPageRepository;
            _advertisementRepo = advertisementRepo;
            _contentCreatorRepo = contentCreatorRepo;
            _videoRepository = videoRepository;
        }
        public async Task<List<long>> Handle(GetCreatorVideoStatisticQuery request, CancellationToken cancellationToken)
        {
            
            var Videos = await _videoRepository.GetCreatedByIdAsync(request.ContentCreatorId);
            var count = Videos.Count;
            long viewCount = 0;
            long likeCount = 0;
            long LatestViews = 0;
            long latestLikes = 0;
            
            for (var i = 0; i < Videos.Count; i++)
            {
                long Views = await _videoPageRepository.GetViewsById(Videos[i].VideoId);
                viewCount = viewCount + Views;
                long Likes = await _videoPageRepository.GetLikesById(Videos[i].VideoId);
                likeCount = likeCount + Likes;
                long latestCreatorViews = await _videoPageRepository.GetLatestCreatorViews(Videos[i].VideoId);
                LatestViews = LatestViews + latestCreatorViews;
                long latestCreatorLikes = await _videoPageRepository.GetLatestCreatorLikes(Videos[i].VideoId);
                latestLikes = latestLikes + latestCreatorLikes;



            }

            List<long> result = new List<long>(){viewCount,likeCount,LatestViews,latestLikes};
            return result;
        }
    }
}

