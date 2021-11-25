﻿using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Commands.Create
{
    public class ContentCreaterCommand : IRequest<Response<long>>
    {
        public string ProfilePhotoPath { get; set; }
        public string CreatorName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public long? CityId { get; set; }
        public long? CountryId { get; set; }
        public long StateId { get; set; }

        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string AdditionalRemark { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? Status { get; set; }
        public bool isPassowrdUpdated { get; set; }
        public bool isDeleted { get; set; }
        public string Password { get; set; }

    }
}
