using Microsoft.AspNetCore.Http;
using Neosoft.FAMS.WebApp.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Neosoft.FAMS.WebApp.Models.AdvertisementModel
{
    public class AddAsset : IValidatableObject
    {
        public long AdvertisementId { get; set; }

        [DisplayName("Advertisement Title")]
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Start Time is required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DateMustBeEqualOrGreaterThanCurrentDateValidation(ErrorMessage = "Start Date cannot be less than today date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Time is required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DateMustBeEqualOrGreaterThanCurrentDateValidation(ErrorMessage = "End Date cannot be less than today date")]
        public DateTime EndDate { get; set; }

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
        [Required]
        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is {0} MB")]
        public IFormFile ProfilePhotoPath { get; set; }

        [Required]
        [MaxFileSize(20 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is {0} MB")]
        public IFormFile VideoPath { get; set; }

        [Required(ErrorMessage = "Placement is required")]
        [DisplayName("Placement")]
        public long? PlacementId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public short? Status { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int result = DateTime.Compare(EndDate, StartDate);
            if (result < 0)
            {
                yield return new ValidationResult("start date must be less than the end date", new[] { "StartDate" });
            }
        }
    }
}
