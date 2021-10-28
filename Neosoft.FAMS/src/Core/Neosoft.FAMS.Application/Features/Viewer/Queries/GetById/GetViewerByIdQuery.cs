using MediatR;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Viewer.Queries.GetById
{
    public class GetViewerByIdQuery:IRequest<ViewerDto>
    {
        public long ViewerId { get; set; }
    }
}
