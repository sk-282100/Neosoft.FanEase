using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllVideoStatistics
{
    public class GetAllVideoStatisticsQueryHandler : IRequestHandler<GetAllVideoStaisticsQuery,List<long>>
    {
        private readonly IVideoPageRepository _videoPageRepository;
        private readonly IMapper _mapper;
        private readonly IContentCreatorRepo _contentCreatorRepo;
        private readonly IVideoRepository _videoRepository;
        public GetAllVideoStatisticsQueryHandler(IVideoPageRepository videoPageRepository, IMapper mapper, IContentCreatorRepo contentCreatorRepo, IVideoRepository videoRepository)
        {
            _videoPageRepository = videoPageRepository;
            _mapper = mapper;
            _contentCreatorRepo = contentCreatorRepo;
            _videoRepository = videoRepository;
        }
        public async Task<List<long>> Handle(GetAllVideoStaisticsQuery request, CancellationToken cancellationToken)
        {
            var stats =  _videoPageRepository.GetAllVideoStatisticsById(request.id);
            //var response = _mapper.Map<List<GetAllVideoStatisticsDto>>(stats);
            return stats;
        }
    }
}
