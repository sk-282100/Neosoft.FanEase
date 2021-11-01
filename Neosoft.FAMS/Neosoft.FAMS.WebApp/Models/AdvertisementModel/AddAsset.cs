using Microsoft.AspNetCore.Http;
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

        [Required(ErrorMessage = "Start Time is required")]
        [DisplayName("Start Time")]
        public DateTime? StartTime { get; set; }

        [Required(ErrorMessage = "End Time is required")]
        [DisplayName("End Time")]
        public DateTime? EndTime { get; set; }

        [Required(ErrorMessage = "Content Type is required")]
        [DisplayName("Content Type")]
        public short? ContentTypeId { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Description { get; set; }


        [Required(ErrorMessage = "Url is required")]
        [DisplayName("Url")]
        public string Url { get; set; }

        public IFormFile ProfilePhotoPath { get; set; }

        [Required(ErrorMessage = "Placement is required")]
        [DisplayName("Placement")]
        public long? PlacementId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public short? Status { get; set; }
    }
}
