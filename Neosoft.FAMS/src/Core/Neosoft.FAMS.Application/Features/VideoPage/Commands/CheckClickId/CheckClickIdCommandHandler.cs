using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.VideoPage.Commands.CheckClickId
{
    public class CheckClickIdCommandHandler : IRequestHandler<CheckClickIdCommand, bool>
    {
        private readonly IVideoPageRepository _videoPageRepository;
        private readonly IMapper _mapper;
        public CheckClickIdCommandHandler(IVideoPageRepository videoPageRepository, IMapper mapper)
        {
            _videoPageRepository = videoPageRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CheckClickIdCommand request, CancellationToken cancellationToken)
        {
            var data = await _videoPageRepository.CheckClickId(request.id);
            if(data != null)
            {

                return true;
            }
            return false;
        }
    }
}
