using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Login.Commands.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<bool>
    {
        public string Username { get; set; }
        public string newPassword { get; set; }
    }
}
