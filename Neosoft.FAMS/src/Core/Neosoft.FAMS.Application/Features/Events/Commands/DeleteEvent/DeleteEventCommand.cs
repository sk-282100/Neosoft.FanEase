using MediatR;
using System;

namespace Neosoft.FAMS.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public string EventId { get; set; }
    }
}
