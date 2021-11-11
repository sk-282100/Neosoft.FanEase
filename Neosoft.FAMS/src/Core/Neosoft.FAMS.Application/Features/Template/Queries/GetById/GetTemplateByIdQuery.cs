using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Neosoft.FAMS.Application.Features.Template.Queries.GetById
{
    public class GetTemplateByIdQuery : IRequest<TemplateListDto>
    {
        public long TemplateId { get; set; }
    }
}
