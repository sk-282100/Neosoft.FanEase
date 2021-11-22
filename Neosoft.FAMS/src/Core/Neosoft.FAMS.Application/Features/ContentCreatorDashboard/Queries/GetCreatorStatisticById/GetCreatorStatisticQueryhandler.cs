using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.GetCreatorStatisticById
{
    public class GetCreatorStatisticQueryhandler : IRequestHandler<GetCreatorStatisticQuery, List<long>>
    {
        private readonly IVideoPageRepository _videoPageRepository;
        private readonly IMapper _mapper;
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IContentCreatorRepo _contentCreatorRepo;
        private readonly IVideoRepository _videoRepository;

        public GetCreatorStatisticQueryhandler(IMapper mapper, IVideoPageRepository videoPageRepository, IAdvertisementRepo advertisementRepo, IContentCreatorRepo contentCreatorRepo, IVideoRepository videoRepository)
        {
            _mapper = mapper;
            _videoPageRepository = videoPageRepository;
            _advertisementRepo = advertisementRepo;
            _contentCreatorRepo = contentCreatorRepo;
            _videoRepository = videoRepository;
        }
        public async Task<List<long>> Handle(GetCreatorStatisticQuery request, CancellationToken cancellationToken)
        {
            
            
            var Videos = await _videoRepository.GetCreatedByIdAsync(request.ContentCreatorId);
            var countOfVideos = Videos.Count;
            var Advertisements = await _advertisementRepo.GetCreatedByIdAsync(request.ContentCreatorId);
            var countofAds = Advertisements.Count;
            var latestVideos = await _videoRepository.GetLatestCreatorVideos(request.ContentCreatorId);
            var countOfLatestVideos = latestVideos.Count;
            var latestAdvertisements = await _advertisementRepo.GetLatestCreatorAdvertisement(request.ContentCreatorId);
            var countOfLatestAdvertisements = latestAdvertisements.Count;
            

            List<long> result = new List<long>() {countOfVideos,countofAds,countOfLatestVideos,countOfLatestAdvertisements};
            return result;

        }
    }
}
