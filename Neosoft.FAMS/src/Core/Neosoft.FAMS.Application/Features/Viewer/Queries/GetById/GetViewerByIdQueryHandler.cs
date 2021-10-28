using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Viewer.Queries.GetById
{
    public class GetViewerByIdQueryHandler : IRequestHandler<GetViewerByIdQuery, ViewerDto>
    {
        private readonly IViewerRepo _viewerRepo;
        private readonly IMapper _mapper;

        public GetViewerByIdQueryHandler(IViewerRepo viewerRepo, IMapper mapper)
        {
            _viewerRepo = viewerRepo;
            _mapper = mapper;
        }
        public async Task<ViewerDto> Handle(GetViewerByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _viewerRepo.GetByIdAsync(request.ViewerId);
            var response = _mapper.Map<ViewerDto>(data);
            return response;

        }
    }
}
