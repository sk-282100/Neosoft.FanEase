using MediatR;

namespace Neosoft.FAMS.Application.Features.Login.Queries
{
    public class CheckOtpQuery : IRequest<int>
    {
        public string Otp { get; set; }
        public string Username { get; set; }
    }
}
