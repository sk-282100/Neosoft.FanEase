using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class CampaignAdvertiseMapping
    {
        [Key]
        public long CampaignAdvertiseMappingId { get; set; }
        public long? CampaignId { get; set; }
        public long? AdvertisementId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long VideoId { get; set; }
    }
}
