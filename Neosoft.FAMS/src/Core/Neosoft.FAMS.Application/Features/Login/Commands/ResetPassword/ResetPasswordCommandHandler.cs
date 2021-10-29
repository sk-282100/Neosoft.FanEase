using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts;
using Neosoft.FAMS.Application.Contracts.Persistence;
using Neosoft.FAMS.Application.Responses;
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
            var data = await _loginRepository.ResetPassword(request.Username, request.Password);
            long id = data.Id;
            data.Password = request.newPassword;
            if (data != null)
            {
                var update = _mapper.Map<Neosoft.FAMS.Domain.Entities.Login>(data);
                await _loginRepository.UpdateAsync(update);

                var Response = new Response<bool> { Data = true, Message = "Updated Successfully", Succeeded = true };
                return true;
            }
            else
            {
                var response = new Response<bool> { Message = "No Data Found", Succeeded = true };
                return false;
            }
        }
    }
}
