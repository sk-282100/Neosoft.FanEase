using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;

namespace Neosoft.FAMS.Application.Features.Template.Queries.GetById
{
   public class GetTemplateByIdQueryHandler : IRequestHandler<GetTemplateByIdQuery,TemplateListDto>
    {
        private readonly ITemplateRepository _template;
        private readonly IMapper _mapper;

        public GetTemplateByIdQueryHandler(ITemplateRepository template, IMapper mapper)
        {
            _template = template;
            _mapper = mapper;
        }

        public async Task<TemplateListDto> Handle(GetTemplateByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _template.GetByIdAsync(request.TemplateId);
            var result = _mapper.Map<TemplateListDto>(data);
            return result;
        }
    }
}
