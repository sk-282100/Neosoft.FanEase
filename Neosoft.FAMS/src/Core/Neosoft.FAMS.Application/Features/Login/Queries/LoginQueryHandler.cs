using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Login.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, Domain.Entities.Login>
    {
        private readonly ILoginRepo _loginRepository;
        private readonly IMapper _mapper;
        public LoginQueryHandler(ILoginRepo loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }
        public async Task<Domain.Entities.Login> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Login result = new Domain.Entities.Login();
           
            var data = await _loginRepository.GetLoginDetail(request.UserName, request.Password);
            if (data != null)
            {
                //data.Password = EncryptionDecryption.DecryptString(data.Password);
                if (data.Id>0 && data.RoleId > 0)
                {
                    result.Id=data.Id;
                    result.RoleId=data.RoleId;
                    result.Username = data.Username;
                    result.Password = data.Password;
                    return result;
                }
            }

            return null;
        }
    }
}
