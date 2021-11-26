using Microsoft.AspNetCore.Http;
using Neosoft.FAMS.WebApp.Models.Validations;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Neosoft.FAMS.WebApp.Models.CreatorModel
{

    public class CreatorRegisteration
    {
        public long ContentCreatorId { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("Profile Photo")]
        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is {0} MB")]
        public IFormFile ProfilePhotoPath { get; set; }

        [DisplayName("Creator Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 3)]
        public string CreatorName { get; set; }

        [Required(ErrorMessage = "Address-1 is required")]
        [StringLength(100, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 30)]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [DisplayName("City")]
        [Required, Range(1, int.MaxValue, ErrorMessage = "Please select City")]
        public int CityId { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please select Country")]
        [DisplayName("Country")]
        public int CountryId { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please select State")]
        [DisplayName("State")]
        public int StateId { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
        ErrorMessage = "Please Enter Valid Email.")]
        public string EmailId { get; set; }

        [DisplayName("Contact")]
        [Required(ErrorMessage = "Contact is required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Can contain only digits and length must be 10")]
        public string MobileNumber { get; set; }

        [Required]
        public bool Status { get; set; }

        [DisplayName("Additional Remark")]
        public string AdditionalRemark { get; set; }

        public string Password { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long CreatedBy { get; set; }
        public bool isPassowrdUpdated { get; set; }
        public bool isDeleted { get; set; }
    }
}
