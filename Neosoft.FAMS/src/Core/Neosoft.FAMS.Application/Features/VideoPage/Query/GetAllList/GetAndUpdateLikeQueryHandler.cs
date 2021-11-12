using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllList
{
    public class GetAndUpdateLikeQueryHandler : IRequestHandler<GetAndUpdateLikeQuery, long>
    {
        private readonly IVideoPageRepository _videoPageRepository;
        private readonly IMapper _mapper;
        public GetAndUpdateLikeQueryHandler(IMapper mapper, IVideoPageRepository videoPageRepository)
        {
            _mapper = mapper;
            _videoPageRepository = videoPageRepository;
        }

        public async Task<long> Handle(GetAndUpdateLikeQuery request, CancellationToken cancellationToken)
        {
            var modify = await _videoPageRepository.UpdateLike(request.videoId, request.viewerId);
            if(modify.IsLiked == false || modify.IsLiked == null)
            {
                modify.IsLiked = true;
            }
            else if(modify.IsLiked == true)
            {
                modify.IsLiked = null;
            }
            var update = _mapper.Map<VideoStatisticsDetail>(modify);
            await _videoPageRepository.UpdateAsync(update);

            var result = await _videoPageRepository.GetLikesById(request.videoId);
            return result;
        }
    }
}
