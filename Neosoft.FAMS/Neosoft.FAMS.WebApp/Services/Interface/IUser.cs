using Neosoft.FAMS.Application.Features.Users.Commands.CreateUser;
using Neosoft.FAMS.Application.Features.Users.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface IUser
    {
        public List<UserListVm> GetAllUserList();

        Task<Guid> SaveUser(CreateUserCommand createUserCommand);
    }
}
