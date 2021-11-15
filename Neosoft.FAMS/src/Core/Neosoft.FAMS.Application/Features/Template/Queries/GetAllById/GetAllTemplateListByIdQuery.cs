using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Neosoft.FAMS.Application.Features.Template.Queries.GetAllById
{
    public class GetAllTemplateListByIdQuery: IRequest<List<GetAllTemplateByIdDto>>
    {
    }
}
