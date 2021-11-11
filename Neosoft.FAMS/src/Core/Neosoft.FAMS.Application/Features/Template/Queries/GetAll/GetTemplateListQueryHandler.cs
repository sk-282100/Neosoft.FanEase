using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Application.Features.Template.Queries.GetAll
{
    public class GetTemplateListQueryHandler : IRequestHandler<GetTemplateListQuery, List<TemplateListDto>>
    {
        private readonly ITemplateRepository _template;
        private readonly IMapper _mapper;

        public GetTemplateListQueryHandler(ITemplateRepository template, IMapper mapper)
        {
            _template = template;
            _mapper = mapper;
        }

        public async Task<List<TemplateListDto>> Handle(GetTemplateListQuery request, CancellationToken cancellationToken)
        {
            var data = await _template.ListAllAsync();
            var result = _mapper.Map<List<TemplateListDto>>(data);
            return result;
        }
    }
}
