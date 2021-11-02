using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Neosoft.FAMS.Application.Features.Advertisement.Commands.CampaignAdvertisement
{
   public class AddCampaignAdvertisementCommand : IRequest<long>
    {
        public long? CampaignId { get; set; }
        public long? AdvertisementId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long VideoId { get; set; }
    }
}
