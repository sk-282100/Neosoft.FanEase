using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Login.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, int>
    {
        private readonly ILoginRepo _loginRepository;
        private readonly IMapper _mapper;
        public LoginQueryHandler(ILoginRepo loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            var data = _loginRepository.GetLoginDetail(request.UserName,request.Password);
            if (data.UserName == request.UserName && data.Password == request.Password)
            {

                return data.RoleID;
            }
            return 0;
        }
    }
}
