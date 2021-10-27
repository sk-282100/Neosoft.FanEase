using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Viewer.Commands.Delete
{
    public class DeleteByIdCommandHandler : IRequestHandler<DeleteViewerByIdCommand, Response<bool>>
    {
        private readonly IViewerRepo _viewerRepo;
        private readonly IMapper _mapper;
        public DeleteByIdCommandHandler(IViewerRepo viewerRepo, IMapper mapper)
        {
            _viewerRepo = viewerRepo;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(DeleteViewerByIdCommand request, CancellationToken cancellationToken)
        {
            _viewerRepo.DeleteAsync(new ViewerDetail { ViewerId=request.ViewerId});
            var response = new Response<bool> { Data = true,Message= "Deleted Successfully" ,Succeeded=true};
            return response;
        }
    }
}
