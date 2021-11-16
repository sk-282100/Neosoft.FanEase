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
            var Advertisements= await _advertisementRepo.ListAllAsync();
            var countOfAdvertisements = Advertisements.Count;
            var Videos = await _videoRepository.ListAllAsync();
            var countOfVideos = Videos.Count;
            var viewCount = _videoPageRepository.GetViewCount();
            List<long> result = new List<long>() { countOfCreators,countOfAdvertisements,countOfVideos,viewCount };
            return result;

        }
    }
}
