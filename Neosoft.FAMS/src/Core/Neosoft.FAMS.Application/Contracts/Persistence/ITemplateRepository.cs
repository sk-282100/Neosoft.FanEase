using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface ITemplateRepository : IAsyncRepository<TemplateDetail>
    {
         Task<TemplateDetail> GetByIdAsync(long id);
         Task<TemplateVideoMapping> AddTemplateVideoAsync(TemplateVideoMapping entity);
         Task<List<TemplateVideoMapping>> GetAllTemplateById();
    }
}
