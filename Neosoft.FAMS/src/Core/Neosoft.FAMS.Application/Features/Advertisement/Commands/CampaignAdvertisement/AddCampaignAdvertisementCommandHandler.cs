using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Advertisement.Commands.CampaignAdvertisement
{
    class AddCampaignAdvertisementCommandHandler : IRequestHandler<AddCampaignAdvertisementCommand, long>
    {
        private readonly IAdvertisementRepo _advertisementRepo;
        private readonly IMapper _mapper;
        public AddCampaignAdvertisementCommandHandler(IAdvertisementRepo advertisementRepo, IMapper mapper)
        {
            _advertisementRepo = advertisementRepo;
            _mapper = mapper;
        }
        public async Task<long> Handle(AddCampaignAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CampaignAdvertiseMapping>(request);
            var data = await _advertisementRepo.AddMapperDataAsync(entity);
            return data.CampaignAdvertiseMappingId;
        }
    }
}
