using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Events.Login.Commands
{
    public class ResetPasswordCommand : IRequest<bool>
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }

        public string RePassword { get; set; }
    }
}
