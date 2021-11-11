using MediatR;
using Neosoft.FAMS.Application.Responses;
using System.Collections.Generic;

namespace Neosoft.FAMS.Application.Features.Users.Queries
{
    public class GetUsersListQuery : IRequest<Response<IEnumerable<UserListVm>>>
    {
    }
}
