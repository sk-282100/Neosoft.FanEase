﻿using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Viewer.Commands.Update
{
    public class UpdateViewerCommand: IRequest<Response<bool>>
    {
        public long ViewerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public long? CityId { get; set; }
        public long? CountryId { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
    }
}
