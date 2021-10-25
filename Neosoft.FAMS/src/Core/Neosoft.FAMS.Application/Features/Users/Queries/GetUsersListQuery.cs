using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Users.Queries
{
   public class GetUsersListQuery : IRequest<Response<IEnumerable<UserListVm>>>
    {
    }
}
