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

namespace Neosoft.FAMS.Application.Features.Login.Commands.ForgotPassword
{
    class AddPasswordResetCommandHandler : IRequestHandler<AddPasswordResetCommand, Response<long>>
    {

        private readonly ILoginRepo _loginRepo;
        private readonly IMapper _mapper;
        public AddPasswordResetCommandHandler(ILoginRepo loginRepo, IMapper mapper)
        {
            _loginRepo = loginRepo;
            _mapper = mapper;
        }
        public Task<Response<long>> Handle(AddPasswordResetCommand request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<PasswordResetRequest>(request);
            record.RequestedOn = DateTime.Now;
            record.ExpiredOn = DateTime.Now.AddMinutes(10);

           
            return null;
        }
    }
}
