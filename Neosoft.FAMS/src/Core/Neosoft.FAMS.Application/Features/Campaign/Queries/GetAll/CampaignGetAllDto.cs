using System;

namespace Neosoft.FAMS.Application.Features.Campaign.Queries.GetAll
{
    public class CampaignGetAllDto
    {
        public long CampaignId { get; set; }
        public string CampaignName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
