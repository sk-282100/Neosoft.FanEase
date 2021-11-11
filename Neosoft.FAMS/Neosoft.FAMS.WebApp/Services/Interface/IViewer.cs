using Neosoft.FAMS.Application.Features.Viewer.Commands.Create;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface IViewer
    {
        public bool checkEmail(string email);
        public List<ViewerDto> GetAllViewer();
        Task<long> SaveViewer(ViewerCreateCommand viewerCreateCommand);
        public ViewerDto GetViewerByEmail(string username);
    }
}
