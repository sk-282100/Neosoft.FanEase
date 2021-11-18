using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.Advertisement.Queries.GetAll;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Application.Features.Advertisement.Queries.GetMappedDataByCampaignId
{
    class GetMappedListByIdQueryHandler : IRequestHandler<GetMappedListByIdQuery, List<AdvertisementListQueryDto>>
    {
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IMapper _mapper;
        public GetMappedListByIdQueryHandler(IAdvertisementRepo advertisementRepo, IMapper mapper)
        {
            _advertisementRepo = advertisementRepo;
            _mapper = mapper;
        }
        public async Task<List<AdvertisementListQueryDto>> Handle(GetMappedListByIdQuery request, CancellationToken cancellationToken)
        {
            var advertisementId = new List<AdvertisementDetail>();
            var mappedData =await _advertisementRepo.GetMappedByIdAsync(request.CampaignId);
            foreach (var data in mappedData)
            {
                long a=0;
                advertisementId.Add(await _advertisementRepo.GetByIdAsync(data.AdvertisementId ?? 0));   
            }

            var result = _mapper.Map<List<AdvertisementListQueryDto>>(advertisementId);
            return result;
        }
    }
}
