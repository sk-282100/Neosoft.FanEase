using MediatR;
using System.Collections.Generic;

namespace Neosoft.FAMS.Application.Features.Login.Queries
{
    public class LoginQuery : IRequest<List<object>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
