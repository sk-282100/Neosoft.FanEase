using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Login.Commands
{
    public class CheckUsernameCommandHandler:IRequestHandler<CheckUsernameCommand,bool>
    {
        private readonly ILoginRepo _loginRepository;
        private readonly IMapper _mapper;
        public CheckUsernameCommandHandler(ILoginRepo loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CheckUsernameCommand request, CancellationToken cancellationToken)
        {
            var data = await _loginRepository.CheckUsername(request.UserName);
            if (data != null)
            {
                return true;
            }
            return false;
        }


    }

}
