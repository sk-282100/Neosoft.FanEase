using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll;
using Neosoft.FAMS.WebApp.Models.CreatorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface ICreator
    {
        public List<ContentCreatorDto> GetAllCreator();
        public Task<long> SaveCreatorDetail(CreatorRegisteration registeration);
    }
}
