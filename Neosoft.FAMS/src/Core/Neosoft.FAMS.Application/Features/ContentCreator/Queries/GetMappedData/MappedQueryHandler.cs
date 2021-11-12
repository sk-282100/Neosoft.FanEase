using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetById;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetMappedData
{
    public class MappedQueryHandler: IRequestHandler<MappedQuery, MappedDto>
    {
        private readonly IContentCreatorRepo _creatorRepo;
        private readonly IMapper _mapper;
        private readonly IVideoRepository _videoRepository;
        private readonly ICampaignDetailRepo _campaignDetailRepo;
        private readonly IAdvertisementRepo _advertisementRepo;
        public MappedQueryHandler(IContentCreatorRepo creatorRepo, IMapper mapper, IVideoRepository videoRepository, ICampaignDetailRepo campaignDetailRepo, IAdvertisementRepo advertisementRepo )
        {
            _creatorRepo = creatorRepo;
            _mapper = mapper;
            _videoRepository = videoRepository;
            _campaignDetailRepo = campaignDetailRepo;
            _advertisementRepo = advertisementRepo;
        }

        public async Task<MappedDto> Handle(MappedQuery request, CancellationToken cancellationToken)
        {
            //var data = await _creatorRepo.GetByIdAsync(request.VideoId);

            var mappedData = await _creatorRepo.GetMappedDataByIdAsync(request.VideoId);
            var advertisementData = new List<AdvertisementDetail>();
            foreach (var data in mappedData)
            {
                advertisementData.Add(await _advertisementRepo.GetByIdAsync(Convert.ToInt64(data.AdvertisementId)));
            }
            
            var campaignData = await _campaignDetailRepo.GetByIdAsync(Convert.ToInt64(mappedData[0].CampaignId));
            var videoData = await _videoRepository.GetByIdAsync(Convert.ToInt64(mappedData[0].VideoId));

            var advertisementMapped = _mapper.Map<List<AdvertisementDetail>>(advertisementData);
            var campaignMapeed = _mapper.Map<CampaignDetail>(campaignData);
            var videoMapped = _mapper.Map<VideoDetail>(videoData);
            var response = new MappedDto()
                {AdvertisementDetail = advertisementMapped, CampaignDetail = campaignMapeed, VideoDetail = videoMapped};

            return response;
        }
    }
}
