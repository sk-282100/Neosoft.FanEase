using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Neosoft.FAMS.Infrastructure.EncryptDecrypt;

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
            var data = await _loginRepository.GetLoginDetail(request.UserName,request.Password);
            //data.Password = EncryptionDecryption.DecryptString(data.Password);
            if (data.Username == request.UserName && data.Password == request.Password)
            {
                return (int)data.RoleId;
            }
            return 0;
        }
    }
}
