using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;

namespace Neosoft.FAMS.Application.Features.Campaign.Commands.Update
{
    public class UpdateCampaignCommand : IRequest<Response<bool>>
    {
        public long CampaignId { get; set; }
        public string CampaignName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
