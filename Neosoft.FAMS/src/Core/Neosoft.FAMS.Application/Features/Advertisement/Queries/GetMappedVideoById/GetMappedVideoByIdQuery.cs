using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Neosoft.FAMS.Application.Features.Advertisement.Queries.GetMappedVideoById
{
    public class GetMappedVideoByIdQuery:IRequest<long>
    {
        public long CampaignId { get; set; }
    }
}
