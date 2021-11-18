using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;

namespace Neosoft.FAMS.Application.Features.Advertisement.Queries.GetMappedVideoById
{
    public class GetMappedVideoByIdQueryHandler : IRequestHandler<GetMappedVideoByIdQuery, long>
    {
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IMapper _mapper;
        public GetMappedVideoByIdQueryHandler(IAdvertisementRepo advertisementRepo, IMapper mapper)
        {
            _advertisementRepo = advertisementRepo;
            _mapper = mapper;
        }
        public async Task<long> Handle(GetMappedVideoByIdQuery request, CancellationToken cancellationToken)
        {
            var mappedData = await _advertisementRepo.GetMappedVideoByIdAsync(request.CampaignId);
            long result = (mappedData==null) ? 0 : (long)mappedData.VideoId;
            return result;
        }
    }
}
