using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllVideoStatistics;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.VideoPage.Commands.CheckClickId
{
    public class CheckClickIdCommandHandler : IRequestHandler<CheckClickIdCommand, bool>
    {
        private readonly IVideoPageRepository _videoPageRepository;
        private readonly IMapper _mapper;
        public CheckClickIdCommandHandler(IVideoPageRepository videoPageRepository, IMapper mapper)
        {
            _videoPageRepository = videoPageRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CheckClickIdCommand request, CancellationToken cancellationToken)
        {
            var data = await _videoPageRepository.CheckClickId(request.viewerId);
            if(data != null)
            {
                return true;
            }
            GetAllVideoStatisticsDto obj = new GetAllVideoStatisticsDto();

            var record = _mapper.Map<VideoStatisticsDetail>(obj);
            record.VideoId = request.videoId;
            record.ClickedBy = request.viewerId;
            record.ViewBy = request.viewerId;
            record.LikeBy = request.viewerId;
            record.SharedBy = request.viewerId;
            await _videoPageRepository.AddAsync(record);
            return false;
        }
    }
}
