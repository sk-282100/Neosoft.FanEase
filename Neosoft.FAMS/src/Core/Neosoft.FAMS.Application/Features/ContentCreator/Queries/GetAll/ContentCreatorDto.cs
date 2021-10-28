﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll
{
    public class ContentCreatorDto
    {
        public long ContentCreatorId { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string CreatorName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public long? CityId { get; set; }
        public long? CountryId { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public bool? Status { get; set; }
        public string AdditionalRemark { get; set; }
        public long LoginId { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}
