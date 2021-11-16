using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetCreatorVideoStatistic
{
    public class GetCreatorVideoStatisticQueryHandler : IRequestHandler<GetCreatorVideoStatisticQuery, GetCreatorVideoStatisticDto>
    {
        private readonly IContentCreatorRepo _creatorRepo;
        private readonly IMapper _mapper;
        private readonly IVideoRepository _videoRepository;
        private readonly IVideoPageRepository _videoPageRepository;
        public GetCreatorVideoStatisticQueryHandler(IContentCreatorRepo creatorRepo, IMapper mapper, IVideoRepository videoRepository, IVideoPageRepository videoPageRepository)
        {
            _creatorRepo = creatorRepo;
            _mapper = mapper;
            _videoRepository = videoRepository;
            _videoPageRepository = videoPageRepository;
        }

        public async Task<GetCreatorVideoStatisticDto> Handle(GetCreatorVideoStatisticQuery request, CancellationToken cancellationToken)
        {
            var videoData = await _videoRepository.GetCreatedByIdAsync(request.CreatedById);
            var videoStatisticData = new List<List<long>>();
            foreach (var data in videoData)
            {
                videoStatisticData.Add(_creatorRepo.GetAllVideoStatisticsById(Convert.ToInt64(data.VideoId)));
            }
            var videoMapped = _mapper.Map<List<VideoDetail>>(videoData);
            var response = new GetCreatorVideoStatisticDto()
                { VideoDetail = videoMapped,VideoStatisticsDetails = videoStatisticData};
            return response;
        }
    }
}
