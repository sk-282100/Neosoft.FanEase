using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Viewer.Commands.Delete
{
    public class DeleteViewerByIdCommand:IRequest<Response<bool>>
    {
        public long ViewerId { get; set; }
    }
}
