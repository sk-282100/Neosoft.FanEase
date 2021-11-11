using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Advertisement.Queries.GetAll
{
    public class AdvertisementListQueryHandler : IRequestHandler<GetAdvertisementListQuery, List<AdvertisementListQueryDto>>
    {
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IMapper _mapper;
        public AdvertisementListQueryHandler(IAdvertisementRepo advertisementRepo, IMapper mapper)
        {
            _advertisementRepo = advertisementRepo;
            _mapper = mapper;
        }

        public async Task<List<AdvertisementListQueryDto>> Handle(GetAdvertisementListQuery request, CancellationToken cancellationToken)
        {
            var data = await _advertisementRepo.ListAllAsync();
            var response = _mapper.Map<List<AdvertisementListQueryDto>>(data);
            return response;
        }
    }
}
