using MediatR;
using Neosoft.FAMS.Application.Responses;

namespace Neosoft.FAMS.Application.Features.Campaign.Commands.Delete
{
    public class DeleteCampaignByIdCommand : IRequest<Response<bool>>
    {
        public long CampaignId { get; set; }
    }
}
