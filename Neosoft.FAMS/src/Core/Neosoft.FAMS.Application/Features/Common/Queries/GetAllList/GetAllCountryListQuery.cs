using MediatR;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;

namespace Neosoft.FAMS.Application.Features.Common.Queries.GetAllList
{
    public class GetAllCountryListQuery : IRequest<Response<IEnumerable<Country>>>
    {

    }
}
