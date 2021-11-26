using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Application.Features.Video.Queries.GetVideoOfCreatorById
{
    public class GetVideoOfCreatorQueryHandler : IRequestHandler<GetVideoOfCreatorQuery, List<GetVideoOfCreatorDto>>
    {
        private readonly IContentCreatorRepo _creatorRepo;
        private readonly IVideoRepository _videoRepo;
        private readonly IMapper _mapper;

        public GetVideoOfCreatorQueryHandler(IContentCreatorRepo creatorRepo, IVideoRepository videoRepo, IMapper mapper)
        {
            _creatorRepo = creatorRepo;
            _videoRepo = videoRepo;
            _mapper = mapper;
        }
        public async Task<List<GetVideoOfCreatorDto>> Handle(GetVideoOfCreatorQuery request, CancellationToken cancellationToken)
        {
            List<GetVideoOfCreatorDto> getVideoOfCreatorDto = new List<GetVideoOfCreatorDto>();
            var videoData = await _videoRepo.GetCreatedByIdAsync(request.CreatedBy);
            for (var i = 0; i < videoData.Count; i++)
            {
                var campaignName = await _videoRepo.GetCampaignName(videoData[i].VideoId);
                if (campaignName == null)
                {
                    campaignName = "Not available";
                }
                getVideoOfCreatorDto.Add(new GetVideoOfCreatorDto()
                {
                    VideoDetail = videoData[i],
                    AssignedCampaign =campaignName ,
                    Views = _videoRepo.GetTotalVideoViewsByIdAsync(videoData[i].VideoId),
                    Clicks = _videoRepo.GetTotalVideoClicksByIdAsync(videoData[i].VideoId)
            });
            }

            return getVideoOfCreatorDto;
       }
    }
}
