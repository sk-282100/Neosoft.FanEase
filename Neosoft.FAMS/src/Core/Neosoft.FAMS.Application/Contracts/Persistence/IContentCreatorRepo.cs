using Neosoft.FAMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Contracts.Persistence
{
    public interface IContentCreatorRepo : IAsyncRepository<ContentCreatorDetail>
    {
    }
}
