﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class CampaignDetail
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
