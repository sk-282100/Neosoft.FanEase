using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;

namespace Neosoft.FAMS.Application.Features.Template.Queries.GetAllById
{
    public class GetAllTemplateListByIdQueryHandler : IRequestHandler<GetAllTemplateListByIdQuery, List<GetAllTemplateByIdDto>>
    {
        private readonly ITemplateRepository _template;
        private readonly IMapper _mapper;

        public GetAllTemplateListByIdQueryHandler(ITemplateRepository template, IMapper mapper)
        {
            _template = template;
            _mapper = mapper;
        }
        public async Task<List<GetAllTemplateByIdDto>> Handle(GetAllTemplateListByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _template.GetAllTemplateById();
            var result = _mapper.Map<List<GetAllTemplateByIdDto>>(data);
            return result;
        }
    }
}
