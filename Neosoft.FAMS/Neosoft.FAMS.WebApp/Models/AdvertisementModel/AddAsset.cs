using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Models.AdvertisementModel
{
    public class AddAsset
    {
        public long AdvertisementId { get; set; }

        [DisplayName("Advertisement Title")]
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short? ContentTypeId { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string VideoPath { get; set; }
        public string Url { get; set; }
        public long? PlacementId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public short? Status { get; set; }
    }
}
