using Neosoft.FAMS.Application.Features.Viewer.Commands.Create;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface IViewer
    {
        public List<ViewerDto> GetAllViewer();
        Task<long> SaveViewer(ViewerCreateCommand viewerCreateCommand);
    }
}
