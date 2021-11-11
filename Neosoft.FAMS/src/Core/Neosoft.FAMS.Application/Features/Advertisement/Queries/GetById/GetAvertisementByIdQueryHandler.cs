using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.Advertisement.Queries.GetAll;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Advertisement.Queries.GetById
{
    public class GetAvertisementByIdQueryHandler : IRequestHandler<GetAvertisementByIdQuery, AdvertisementListQueryDto>
    {
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IMapper _mapper;
        public GetAvertisementByIdQueryHandler(IAdvertisementRepo advertisementRepo, IMapper mapper)
        {
            _advertisementRepo = advertisementRepo;
            _mapper = mapper;
        }

        public async Task<AdvertisementListQueryDto> Handle(GetAvertisementByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _advertisementRepo.GetByIdAsync(request.AdvertisementId);
            var response = _mapper.Map<AdvertisementListQueryDto>(data);
            return response;
        }
    }
}
