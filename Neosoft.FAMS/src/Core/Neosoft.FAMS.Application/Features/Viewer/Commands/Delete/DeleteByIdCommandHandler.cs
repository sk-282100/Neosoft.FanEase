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
            var data = await _viewerRepo.GetByIdAsync(request.ViewerId);
            if (data != null)
            {
                await _viewerRepo.DeleteAsync(data);
                var response = new Response<bool> { Data = true, Message = "Deleted Successfully", Succeeded = true };
                return response;
            }
            else
            {
                var response = new Response<bool> { Message = "No Data Found", Succeeded = true };
                return response;
            }
           
        }
    }
}
