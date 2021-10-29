using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Events.Login.Commands
{
    public class ResetPasswordCommand : IRequest<bool>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string newPassword { get; set; }

        
    }
}
