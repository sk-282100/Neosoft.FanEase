using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Login.Commands
{
    public class CheckUsernameCommand:IRequest<bool>
    {
        public string UserName { get; set; }
    }
}
