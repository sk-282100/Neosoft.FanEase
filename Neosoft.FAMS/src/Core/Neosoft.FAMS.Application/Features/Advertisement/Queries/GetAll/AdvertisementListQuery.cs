using MediatR;
using System.Collections.Generic;

namespace Neosoft.FAMS.Application.Features.Advertisement.Queries.GetAll
{
    public class GetAdvertisementListQuery : IRequest<List<AdvertisementListQueryDto>>
    {
    }
}
