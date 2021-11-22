﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.TopCampaign
{
    public class GetTopCampaignQuery : IRequest<List<string>>
    {
        public long ContentCreatorId { get; set; }
    }
}
