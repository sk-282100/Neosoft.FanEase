using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Campaign.Queries.GetAll
{
    class CampaignGetAllQueryHandler : IRequestHandler<CampaignGetAllQuery, List<CampaignGetAllDto>>
    {
        private readonly ICampaignDetailRepo _campaignDetailRepo;
        private readonly IMapper _mapper;
        public CampaignGetAllQueryHandler(ICampaignDetailRepo campaignDetailRepo, IMapper mapper)
        {
            _campaignDetailRepo = campaignDetailRepo;
            _mapper = mapper;
        }

        public async Task<List<CampaignGetAllDto>> Handle(CampaignGetAllQuery request, CancellationToken cancellationToken)
        {
            var data = await _campaignDetailRepo.GetAllAsync();
            var response = _mapper.Map<List<CampaignGetAllDto>>(data);
            return response;
        }
    }
}
