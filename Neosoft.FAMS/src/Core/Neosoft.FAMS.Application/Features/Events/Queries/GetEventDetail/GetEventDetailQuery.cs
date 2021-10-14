using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;

namespace Neosoft.FAMS.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery : IRequest<Response<EventDetailVm>>
    {
        public string Id { get; set; }
    }
}
