using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Delete;
using Neosoft.FAMS.Application.Features.ContentCreator.Commands.Update;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface ICreator
    {
        public List<ContentCreatorDto> GetAllCreator();
        public Task<long> SaveCreatorDetail(UpdateCreatorByIdCommand registeration);
        public ContentCreatorDto GetCreatorById(long id);
        public Task<bool> UpdateCreatorDetail(UpdateCreatorByIdCommand update);
        public ContentCreatorDto GetCreatorByEmail(string username);
        public Task<bool> DeleteCreator(DeleteCreatorByIdCommand command);

    }
}
