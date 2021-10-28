using MediatR;
using Neosoft.FAMS.Application.Features.Advertisement.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Advertisement.Queries.GetById
{
    public class GetAvertisementByIdQuery : IRequest<AdvertisementListQueryDto>
    {
        public long AdvertisementId { get; set; }
    }
}
