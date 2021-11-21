using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Neosoft.FAMS.WebApp.Models.Validations;

namespace Neosoft.FAMS.WebApp.Models.CampaignModel
{
    public class CreateCampaign : IValidatableObject
    {
        public long CampaignId { get; set; }

        [DisplayName("Creator Name")]
        [Required(ErrorMessage = "Campaign Name is required")]
        [StringLength(100, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 3)]
        public string CampaignName { get; set; }


        [Required(ErrorMessage = "Start Date is required")]
        [DateMustBeEqualOrGreaterThanCurrentDateValidation(ErrorMessage = "Start Date cannot be less than today date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        [DateMustBeEqualOrGreaterThanCurrentDateValidation(ErrorMessage = "End Date cannot be less than today date")]
        public DateTime EndDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDeleted { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int result = DateTime.Compare(EndDate,StartDate);
            if (result < 0)
            {
                yield return new ValidationResult("start date must be less than the end date", new[] { "StartDate" });
            }
        }
    }
}
