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
    public class GetAndUpdateDislikeQueryHandler : IRequestHandler<GetAndUpdateDislikeQuery, long>
    {
        private readonly IVideoPageRepository _videoPageRepository;
        private readonly IMapper _mapper;
        public GetAndUpdateDislikeQueryHandler(IMapper mapper, IVideoPageRepository videoPageRepository)
        {
            _mapper = mapper;
            _videoPageRepository = videoPageRepository;
        }

        public async Task<long> Handle(GetAndUpdateDislikeQuery request, CancellationToken cancellationToken)
        {
            var modify = await _videoPageRepository.UpdateDislike(request.videoId, request.viewerId);
            if (modify.IsLiked == true || modify.IsLiked == null)
            {
                modify.IsLiked = false;
            }
            else if (modify.IsLiked == false)
            {
                modify.IsLiked = null;
            }
            var update = _mapper.Map<VideoStatisticsDetail>(modify);
            await _videoPageRepository.UpdateAsync(update);

            var result = await _videoPageRepository.GetDislikesById(request.videoId);
            return result;
        }
    }
}