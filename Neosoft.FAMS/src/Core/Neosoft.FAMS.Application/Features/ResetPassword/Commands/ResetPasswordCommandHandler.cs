using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Events.Login.Commands
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly ILoginRepo _loginRepository;
        private readonly IMapper _mapper;
        public ResetPasswordCommandHandler(ILoginRepo loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            _loginRepository.ResetPassword(request.newPassword, request.oldPassword);
            return true;
        }


    }
}
