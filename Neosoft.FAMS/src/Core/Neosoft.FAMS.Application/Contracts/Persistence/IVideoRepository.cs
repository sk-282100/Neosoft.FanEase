using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface IVideoRepository: IAsyncRepository<VideoDetail>
    {
        Task<VideoDetail> GetByIdAsync(long id);
    }
}
