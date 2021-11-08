using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Models.CreatorModel
{
    public class CreatorRegisteration
    {
        public long ContentCreatorId { get; set; }

        [DisplayName("Profile Photo")]
        public IFormFile ProfilePhotoPath { get; set; }

        [DisplayName("Creator Name")]
        [Required(ErrorMessage ="Name is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string CreatorName { get; set; }

        [Required(ErrorMessage ="Address-1 is required")]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage ="City is requires")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [DisplayName("Country")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "State is required")]
        [DisplayName("State")]
        public int StateId { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage ="Email is required")]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
        ErrorMessage = "**Please Enter Valid Email.")]
        public string EmailId { get; set; }

        [DisplayName("Mobile Number")]
        [Required(ErrorMessage = "Mobile Number cannot be blank")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Can contain only digits and length must be 10")]
        public string MobileNumber { get; set; }

        [Required]
        public bool Status { get; set; }

        [DisplayName("Additional Remark")]
        public string AdditionalRemark { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long CreatedBy { get; set; }
    }
}
