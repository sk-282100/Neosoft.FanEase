using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Neosoft.FAMS.Application.Features.Advertisement.Queries.GetAll;

namespace Neosoft.FAMS.Application.Features.Advertisement.Queries.GetMappedDataByCampaignId
{
    public class GetMappedListByIdQuery:IRequest<List<AdvertisementListQueryDto>>
    {
        public long CampaignId { get; set; }
    }
}
