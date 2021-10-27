using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll
{
    public class ViewerDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public long? CityId { get; set; }
        public long? CountryId { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
