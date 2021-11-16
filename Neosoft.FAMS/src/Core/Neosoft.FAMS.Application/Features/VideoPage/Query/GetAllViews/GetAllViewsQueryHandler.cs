using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllViews
{
    public class GetAllViewsQueryHandler : IRequestHandler<GetAllViewsQuery, long>
    {
        private readonly IVideoPageRepository _videoPageRepository;
        private readonly IMapper _mapper;
        public GetAllViewsQueryHandler(IMapper mapper, IVideoPageRepository videoPageRepository)
        {
            _mapper = mapper;
            _videoPageRepository = videoPageRepository;
        }
        public async Task<long> Handle(GetAllViewsQuery request, CancellationToken cancellationToken)
        {
            var viewCount = _videoPageRepository.GetViewCount();
            return viewCount;
        }
    }
}
