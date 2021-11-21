using AutoMapper;
using MediatR;
using Neosoft.FAMS.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Features.Login.Queries
{
    public class CheckOtpQueryHandler : IRequestHandler<CheckOtpQuery, int>
    {
        private readonly ILoginRepo _loginRepository;
        private readonly IMapper _mapper;
        public CheckOtpQueryHandler(ILoginRepo loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CheckOtpQuery request, CancellationToken cancellationToken)
        {
            string Username = request.Username;
            var data = await _loginRepository.CheckUsername(Username);
            //if (data.Username == request.UserName)
            //{
            long LoginId = data.Id;
                var result = await _loginRepository.CheckOtp(LoginId,request.Otp);
                if (result != null)
                {
                    DateTime expiredDate = (DateTime)result.ExpiredOn;
                    int check = DateTime.Compare(expiredDate, DateTime.Now);
                    if (check >= 0 && result.ValidCode == request.Otp)
                    {
                        return (int)result.LoginId;
                    }
                 }
                //}
            return 0;
        }
    }
}
