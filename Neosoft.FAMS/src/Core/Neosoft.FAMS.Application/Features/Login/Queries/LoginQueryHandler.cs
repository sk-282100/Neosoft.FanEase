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
    public class LoginQueryHandler : IRequestHandler<LoginQuery, List<object>>
    {
        private readonly ILoginRepo _loginRepository;
        private readonly IMapper _mapper;
        public LoginQueryHandler(ILoginRepo loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }
        public async Task<List<object>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            List<object> result = new List<object>();
            var data = await _loginRepository.GetLoginDetail(request.UserName,request.Password);
            if (data != null)
            {
                //data.Password = EncryptionDecryption.DecryptString(data.Password);
                if (data.Username == request.UserName && data.Password == request.Password)
                {
                    result.Add(data.Id);
                    result.Add(data.RoleId);

                    return result;
                }
            }

            return null;
        }
    }
}
