using Neosoft.FAMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface IContentCreatorRepo : IAsyncRepository<ContentCreatorDetail>
    {
        Task<ContentCreatorDetail> GetByIdAsync(long id);
        Task<Login> AddLoginDetailAsync(string emailId, string password);
        Task<ContentCreatorDetail> GetByEmailAsync(string username);
        Task<List<ContentCreatorDetail>> GetAllCreator();
    }
}
