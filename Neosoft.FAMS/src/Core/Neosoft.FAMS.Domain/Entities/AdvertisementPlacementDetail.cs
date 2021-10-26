using System;
using System.Collections.Generic;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class AdvertisementPlacementDetail
    {
        public long AdvertisementPlacementId { get; set; }
        public string AdvertisementPlacement { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
