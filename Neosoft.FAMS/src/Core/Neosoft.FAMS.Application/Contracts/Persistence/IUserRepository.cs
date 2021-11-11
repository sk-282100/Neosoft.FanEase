using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<UserDemo>
    {
        Task<List<UserDemo>> GetAllUserList();

        // Task<UserDemo> SaveUserDetail(UserDemo user);
    }
}
