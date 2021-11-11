using MediatR;
using Neosoft.FAMS.Application.Responses;

namespace Neosoft.FAMS.Application.Features.Login.Commands.ForgotPassword
{
    class AddPasswordResetCommand : IRequest<Response<long>>
    {
        public string ValidCode { get; set; }
    }
}
