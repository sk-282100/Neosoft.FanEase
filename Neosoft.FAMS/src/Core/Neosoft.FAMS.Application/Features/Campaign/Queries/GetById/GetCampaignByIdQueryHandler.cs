using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.Campaign.Queries.GetAll;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Campaign.Queries.GetById
{
    class GetCampaignByIdQueryHandler : IRequestHandler<GetCampaignByIdQuery, CampaignGetAllDto>
    {
        private readonly ICampaignDetailRepo _campaignDetailRepo;
        private readonly IMapper _mapper;
        public GetCampaignByIdQueryHandler(ICampaignDetailRepo campaignDetailRepo, IMapper mapper)
        {
            _campaignDetailRepo = campaignDetailRepo;
            _mapper = mapper;
        }

        public async Task<CampaignGetAllDto> Handle(GetCampaignByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _campaignDetailRepo.GetByIdAsync(request.CampaignId);
            var response = _mapper.Map<CampaignGetAllDto>(data);
            return response;
        }
    }
}
