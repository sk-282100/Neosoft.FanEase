using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Advertisement.Queries.GetAll
{
    public class GetAdvertisementListQuery : IRequest<List<AdvertisementListQueryDto>>
    {
    }
}
