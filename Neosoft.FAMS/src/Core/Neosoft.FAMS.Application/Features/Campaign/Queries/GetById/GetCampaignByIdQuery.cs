using MediatR;
using Neosoft.FAMS.Application.Features.Campaign.Queries.GetAll;

namespace Neosoft.FAMS.Application.Features.Campaign.Queries.GetById
{
    public class GetCampaignByIdQuery : IRequest<CampaignGetAllDto>
    {
        public long CampaignId { get; set; }
    }
}
