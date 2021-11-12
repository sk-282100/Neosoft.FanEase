using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetMappedData
{
    public class MappedDto
    {
        public VideoDetail VideoDetail { get; set; }
        public CampaignDetail CampaignDetail { get; set; }
        public List<AdvertisementDetail> AdvertisementDetail { get; set; }
    }
}
