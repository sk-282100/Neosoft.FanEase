using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;

namespace Neosoft.FAMS.Application.Features.VideoPage.Query.CheckIsLikedById
{
    public class CheckIsLikedByIdQueryHandler : IRequestHandler<CheckIsLikedByIdQuery, bool>
    {
        private readonly IVideoPageRepository _videoPageRepository;
        private readonly IMapper _mapper;
        public CheckIsLikedByIdQueryHandler(IMapper mapper, IVideoPageRepository videoPageRepository)
        {
            _mapper = mapper;
            _videoPageRepository = videoPageRepository;
        }
        public async Task<bool> Handle(CheckIsLikedByIdQuery request, CancellationToken cancellationToken)
        {
            bool isLiked = await _videoPageRepository.CheckLikeById(request.VideoId, request.ViewerId);
            if (isLiked)
                return true;
            return false ;
        }
    }
}
