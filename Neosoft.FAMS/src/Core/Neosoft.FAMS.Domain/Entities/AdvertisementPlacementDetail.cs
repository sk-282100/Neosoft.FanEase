using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class AdvertisementPlacementDetail
    {
        [Key]
        public long AdvertisementPlacementId { get; set; }
        public string AdvertisementPlacement { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
