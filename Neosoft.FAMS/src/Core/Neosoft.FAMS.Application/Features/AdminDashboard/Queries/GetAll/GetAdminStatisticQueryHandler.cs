using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Neosoft.FAMS.Application.Contracts.Persistence;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetAll
{
    public class GetAdminStatisticQueryHandler : IRequestHandler<GetAdminStatisticQuery, List<long>>
    {
        private readonly IVideoPageRepository _videoPageRepository;
        private readonly IMapper _mapper;
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IContentCreatorRepo _contentCreatorRepo;
        private readonly IVideoRepository _videoRepository;
        
        public GetAdminStatisticQueryHandler(IMapper mapper, IVideoPageRepository videoPageRepository, IAdvertisementRepo advertisementRepo, IContentCreatorRepo contentCreatorRepo,IVideoRepository videoRepository)
        {
            _mapper = mapper;
            _videoPageRepository = videoPageRepository;
            _advertisementRepo = advertisementRepo;
            _contentCreatorRepo = contentCreatorRepo;
            _videoRepository = videoRepository;
        }
        public async Task<List<long>> Handle(GetAdminStatisticQuery request, CancellationToken cancellationToken)
        {
            var Creators = await _contentCreatorRepo.GetAllCreator();
            var countOfCreators=Creators.Count;
            var Advertisements= await _advertisementRepo.GetAllAssets();
            var countOfAdvertisements = Advertisements.Count;
            var countOfVideos = _videoRepository.GetAllVideoCount();
            var viewCount = _videoPageRepository.GetViewCount();
            var latestCreator = await _contentCreatorRepo.GetLatestCreator();
            var countOfLatestCreator = latestCreator.Count;
            var latestAdvertisement = await _advertisementRepo.GetLatestAdvertisement();
            var countOfLatestAd = latestAdvertisement.Count;
            var latestVideo = await _videoRepository.GetLatestVideo();
            var countOfLatestVideo = latestVideo.Count;
            var latestViews = await _videoPageRepository.GetLatestViews();
            var countOfLatesViews = latestViews.Count;



            List<long> result = new List<long>() { countOfCreators,countOfAdvertisements,countOfVideos,viewCount ,countOfLatestCreator, countOfLatestAd, countOfLatestVideo, countOfLatesViews };
            return result;

        }
    }
}
