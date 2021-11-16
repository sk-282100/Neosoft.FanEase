using System;
using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll
{
    class ContentCreatorQueryHandler : IRequestHandler<ContentCreatorQuery, List<ContentCreatorDto>>
    {
        private readonly IContentCreatorRepo _creatorRepo;
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;
        public ContentCreatorQueryHandler(IContentCreatorRepo creatorRepo, IVideoRepository videoRepository, IMapper mapper)
        {
            _creatorRepo = creatorRepo;
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<List<ContentCreatorDto>> Handle(ContentCreatorQuery request, CancellationToken cancellationToken)
        {
            var creatorData = await _creatorRepo.GetAllCreator();
            var response = _mapper.Map<List<ContentCreatorDto>>(creatorData);
            foreach (var data in response)
            {
                data.TotalVideos=_videoRepository.GetTotalVideoByIdAsync(Convert.ToInt64(data.ContentCreatorId));
            }

            return response;
        }
    }
}
