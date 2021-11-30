using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Neosoft.FAMS.WebApp.Models.ViewerModel
{
    public class ViewerRegisteration
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        [Required(ErrorMessage = "Middle Name is required")]
        [StringLength(100, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 3)]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(100, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address-1 is required")]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "Address-2 is required")]
        public string Address2 { get; set; }


        [DisplayName("City")]
        [Required, Range(1, int.MaxValue, ErrorMessage = "Please select City")]
        public int CityId { get; set; }


        [DisplayName("Country")]
        [Required, Range(1, int.MaxValue, ErrorMessage = "Please select Country")]
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


        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Should have at least one lower case,at least one upper case,at least one number,at least one special character,Minimum 8 characters")]
        public string Password { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long LoginId { get; set; }
    }
}
