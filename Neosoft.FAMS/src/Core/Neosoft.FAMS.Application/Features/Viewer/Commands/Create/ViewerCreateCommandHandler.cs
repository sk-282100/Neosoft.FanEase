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

namespace Neosoft.FAMS.Application.Features.Viewer.Commands.Create
{
    class ViewerCreateCommandHandler : IRequestHandler<ViewerCreateCommand, Response<long>>
    {

        private readonly IViewerRepo _viewerRepo;
        private readonly IMapper _mapper;
        public ViewerCreateCommandHandler(IViewerRepo viewerRepo, IMapper mapper)
        {
            _viewerRepo = viewerRepo;
            _mapper = mapper;
        }
        public async Task<Response<long>> Handle(ViewerCreateCommand request, CancellationToken cancellationToken)
        {

            var validator = new ViewerCommandValidator(_viewerRepo);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var data=await _viewerRepo.AddAsync(_mapper.Map<ViewerDetail>(request));
            var response = new Response<long>(data.ViewerId,"Inserted Successfully"); 
            return response;
        }
    }
}
