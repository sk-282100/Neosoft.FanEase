using System;
using System.Collections.Generic;
using System.Text;
using Neosoft.FAMS.Domain.Entities;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface ITemplateRepository : IAsyncRepository<TemplateDetail>
    {

    }
}
