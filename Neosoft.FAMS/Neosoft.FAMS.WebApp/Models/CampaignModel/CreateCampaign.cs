using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Models.CampaignModel
{
    public class CreateCampaign
    {
        [DisplayName("Creator Name")]
        [Required(ErrorMessage = "Campaign Name is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string CampaignName { get; set; }


        [Required(ErrorMessage = "Date is required")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime? EndDate { get; set; }
    }
}
