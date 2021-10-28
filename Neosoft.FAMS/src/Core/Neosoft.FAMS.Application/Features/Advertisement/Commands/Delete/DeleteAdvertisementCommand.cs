using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Advertisement.Commands.Delete
{
    public class DeleteAdvertisementCommand : IRequest<Response<bool>>
    {
        public long AdvertisementId { get; set; }
    }

}
