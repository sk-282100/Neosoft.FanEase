using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Neosoft.FAMS.Application.Features.Template.Queries
{
    public class GetTemplateListQuery : IRequest<List<TemplateListDto>>
    {
    }
}
