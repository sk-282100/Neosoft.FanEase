﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        public ContentCreatorQueryHandler(IContentCreatorRepo creatorRepo, IMapper mapper)
        {
            _creatorRepo = creatorRepo;
            _mapper = mapper;
        }

        public async Task<List<ContentCreatorDto>> Handle(ContentCreatorQuery request, CancellationToken cancellationToken)
        {
            var data = await _creatorRepo.GetAllCreator();
            var response = _mapper.Map<List<ContentCreatorDto>>(data);
            return response;
        }
    }
}
