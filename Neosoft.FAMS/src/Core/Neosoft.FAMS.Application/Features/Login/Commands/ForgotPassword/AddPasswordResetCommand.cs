using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Login.Commands.ForgotPassword
{
    class AddPasswordResetCommand:IRequest<Response<long>>
    {
        public string ValidCode { get; set; }
    }
}
