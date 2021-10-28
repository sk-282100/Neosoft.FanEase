using MediatR;
using Neosoft.FAMS.Application.Features.Campaign.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Campaign.Queries.GetById
{
    public class GetCampaignByIdQuery : IRequest<CampaignGetAllDto>
    {
        public long CampaignId { get; set; }
    }
}
