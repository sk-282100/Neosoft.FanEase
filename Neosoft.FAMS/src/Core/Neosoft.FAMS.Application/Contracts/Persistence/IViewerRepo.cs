using Neosoft.FAMS.Domain.Entities;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface IViewerRepo : IAsyncRepository<ViewerDetail>
    {
        Task<ViewerDetail> GetByIdAsync(long id);
        Task<Login> AddLoginDetailAsync(string emailId, string password);
        Task<ViewerDetail> GetByEmailAsync(string username);
    }
}
