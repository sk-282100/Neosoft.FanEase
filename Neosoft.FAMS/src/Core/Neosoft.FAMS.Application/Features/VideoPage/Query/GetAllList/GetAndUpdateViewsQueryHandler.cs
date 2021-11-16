using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllList
{
    public class GetAndUpdateViewsQueryHandler : IRequestHandler<GetAndUpdateViewsQuery, long>
    {
        private readonly IVideoPageRepository _videoPageRepository;
        private readonly IMapper _mapper;
        public GetAndUpdateViewsQueryHandler(IMapper mapper, IVideoPageRepository videoPageRepository)
        {
            _mapper = mapper;
            _videoPageRepository = videoPageRepository;
        }

        public async Task<long> Handle(GetAndUpdateViewsQuery request, CancellationToken cancellationToken)
        {
            var modify = await _videoPageRepository.UpdateViews(request.videoId, request.viewerId);
            if (modify.IsViewed == false || modify.IsViewed == null)
            {
                modify.ViewOn = DateTime.Now;
                modify.IsViewed = true;
            }
            
            var update = _mapper.Map<VideoStatisticsDetail>(modify);
            await _videoPageRepository.UpdateAsync(update);

            var result = await _videoPageRepository.GetViewsById(request.videoId);
            return result;
        }
    }
}
