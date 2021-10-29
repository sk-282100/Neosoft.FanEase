using Neosoft.FAMS.Application.Features.Viewer.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface IViewer
    {
        //public List<UserListVm> GetAllUserList();

        Task<long> SaveViewer(ViewerCreateCommand viewerCreateCommand);
    }
}
