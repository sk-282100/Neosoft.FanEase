using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
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
            var result = await _videoPageRepository.GetDisikesById(request.videoId);
            return result;
        }
    }
}