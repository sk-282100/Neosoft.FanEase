using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Login.Commands.ForgotPassword
{
        public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, bool> 
        {
        private readonly ILoginRepo _loginRepository;
        private readonly IContentCreatorRepo _creator;
        private readonly IMapper _mapper;
        
        public ForgotPasswordCommandHandler(ILoginRepo loginRepository, IContentCreatorRepo creator, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _creator = creator;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var data = await _loginRepository.ResetPassword(request.Username, request.newPassword);
            long id = data.Id;
            data.Password = request.newPassword;
            if (data != null)
            {
                var update = _mapper.Map<Neosoft.FAMS.Domain.Entities.Login>(data);
                await _loginRepository.UpdateAsync(update);
                return true;
            }
            return false;
        }
    }
}

