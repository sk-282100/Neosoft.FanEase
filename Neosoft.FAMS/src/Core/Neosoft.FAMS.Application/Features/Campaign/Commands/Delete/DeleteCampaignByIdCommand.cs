using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Campaign.Commands.Delete
{
    public class DeleteCampaignByIdCommand : IRequest<Response<bool>>
    {
        public long  CampaignId{ get; set; }
    }
}
