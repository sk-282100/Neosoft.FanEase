using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll
{
    public class ViewerQueryHandler : IRequestHandler<ViewerQuery, List<ViewerDto>>
    {
        private readonly IViewerRepo _viewerRepo;
        private readonly IMapper _mapper;

        public ViewerQueryHandler(IViewerRepo viewerRepo, IMapper mapper)
        {
            _viewerRepo = viewerRepo;
            _mapper = mapper;
        }
        public async Task<List<ViewerDto>> Handle(ViewerQuery request, CancellationToken cancellationToken)
        {
            var data = await _viewerRepo.ListAllAsync();
            var response = _mapper.Map<List<ViewerDto>>(data);
            return response;

        }
    }

}
