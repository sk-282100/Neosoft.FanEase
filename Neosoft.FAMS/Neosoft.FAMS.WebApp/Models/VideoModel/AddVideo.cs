using Microsoft.AspNetCore.Http;
using Neosoft.FAMS.WebApp.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Neosoft.FAMS.WebApp.Models.VideoModel
{
    public class AddVideo : IValidatableObject
    {

        public long VideoId { get; set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is {0} MB")]
        public IFormFile VideoImage { get; set; }


        [Required(ErrorMessage = "Start Time is required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DateMustBeEqualOrGreaterThanCurrentDateValidation(ErrorMessage = "Date cannot be less than today date")]

        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Time is required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DateMustBeEqualOrGreaterThanCurrentDateValidation(ErrorMessage = "Date cannot be less than today date")]

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Video Title is required")]
        [MaxLength(30, ErrorMessage = "Title Length Cannot Exceed 30 characters")]
        public string Title { get; set; }

        public short? VideoTypeId { get; set; }
        public short? PlayerTypeId { get; set; }

        public string? VideoUrl { get; set; }
        [Required(ErrorMessage = "Please upload video file")]
        public IFormFile UploadVideoPath { get; set; }
        public short? VideoCategoryId { get; set; }
        public short? VideoStatus { get; set; }
        public bool? PublishStatus { get; set; }
        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MinLength(10, ErrorMessage = "Description Length Cannot be Less than 10 characters")]
        public string Decription { get; set; }
        public bool? IsDeleted { get; set; }

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
