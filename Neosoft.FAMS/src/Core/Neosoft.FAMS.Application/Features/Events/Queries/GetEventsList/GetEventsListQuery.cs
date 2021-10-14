using MediatR;
using Neosoft.FAMS.Application.Responses;
using System.Collections.Generic;

namespace Neosoft.FAMS.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery : IRequest<Response<IEnumerable<EventListVm>>>
    {

    }
}
