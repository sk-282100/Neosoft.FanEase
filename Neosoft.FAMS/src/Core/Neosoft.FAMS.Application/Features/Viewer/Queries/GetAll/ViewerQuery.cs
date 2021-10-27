using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll
{
    public class ViewerQuery:IRequest<List<ViewerDto>>
    {
    }
}
