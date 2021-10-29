using Neosoft.FAMS.Application.Features.Video.Command.Create;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface IVideo
    {
        public List<VideoGetAllDto> GetAllVideoList();

        Task<long> CreateVideo(VideoCreateCommand videocreateCommand);
    }
}
