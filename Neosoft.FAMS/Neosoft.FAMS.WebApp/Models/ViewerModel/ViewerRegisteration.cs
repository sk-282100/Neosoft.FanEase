using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Models.ViewerModel
{
    public class ViewerRegisteration
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        [Required(ErrorMessage = "Middle Name is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address-1 is required")]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "Address-2 is required")]
        public string Address2 { get; set; }


        [DisplayName("City")]
        [Required(ErrorMessage = "City is required")]
        public int CityId { get; set; }

        
        [DisplayName("Country")]
        [Required(ErrorMessage = "Country is required")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "State is required")]
        [DisplayName("State")]
        public int StateId { get; set; }


        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$",
        ErrorMessage = "Please Enter Valid Email.")]
        public string EmailId { get; set; }

        
        [DisplayName("Mobile Number")]
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Can contain only digits and length must be 10")]
        public string MobileNumber { get; set; }

        
        [DisplayName("Password")]
        [Required]
        public string Password { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long LoginId { get; set; }
    }
}
