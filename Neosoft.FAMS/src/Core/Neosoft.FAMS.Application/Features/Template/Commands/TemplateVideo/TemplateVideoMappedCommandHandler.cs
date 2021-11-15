using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Application.Features.Template.Commands.TemplateVideo
{
    public class TemplateVideoMappedCommandHandler : IRequestHandler<TemplateVideoMappedCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly ITemplateRepository _templateRepository;
        public TemplateVideoMappedCommandHandler(IMapper mapper,ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
            _mapper = mapper;
        }
        public async Task<long> Handle(TemplateVideoMappedCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TemplateVideoMapping>(request);
            var data = await _templateRepository.AddTemplateVideoAsync(entity);
            return data.TemplateVideoMappingId;
        }
    }
}
