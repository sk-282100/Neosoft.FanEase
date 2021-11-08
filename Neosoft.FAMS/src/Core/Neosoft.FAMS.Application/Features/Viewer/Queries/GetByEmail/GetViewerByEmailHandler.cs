using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll;

namespace Neosoft.FAMS.Application.Features.Viewer.Queries.GetByEmail
{
    class GetViewerByEmailHandler : IRequestHandler<GetViewerByEmailQuery, ViewerDto>
    {
        private readonly IViewerRepo _viewerRepo;
        private readonly IMapper _mapper;
        public GetViewerByEmailHandler(IViewerRepo viewerRepo, IMapper mapper)
        {
            _viewerRepo = viewerRepo;
            _mapper = mapper;
        }

        public async Task<ViewerDto> Handle(GetViewerByEmailQuery request, CancellationToken cancellationToken)
        {
            var data = await _viewerRepo.GetByEmailAsync(request.Username);
            var response = _mapper.Map<ViewerDto>(data);
            return response;
        }
    }
}
