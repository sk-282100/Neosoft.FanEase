using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.Template.Queries.GetAllById;

namespace Neosoft.FAMS.Application.Features.Template.Queries.GetAdvertisementByVideoId
{
    public class VideoAdvertisementByVideoIdQueryHandler : IRequestHandler<VideoAdvertisementByVideoIdQuery, List<GetAllTemplateByIdDto>>
    {
        private readonly ITemplateRepository _template;
        private readonly IMapper _mapper;

        public VideoAdvertisementByVideoIdQueryHandler(ITemplateRepository template, IMapper mapper)
        {
            _template = template;
            _mapper = mapper;
        }
        public async Task<List<GetAllTemplateByIdDto>> Handle(VideoAdvertisementByVideoIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _template.GetAdvertisementByVideoIdAsync(request.VideoId);
            var result = _mapper.Map<List<GetAllTemplateByIdDto>>(data);
            return result;
        }
    }
}
