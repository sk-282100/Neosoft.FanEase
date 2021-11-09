using Neosoft.FAMS.Application.Features.Video.Command.Create;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.Video.Commands.Update;
using Neosoft.FAMS.Application.Features.Video.Commands.Delete;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface IVideo
    {
        public List<VideoGetAllDto> GetAllVideoList();

        public VideoGetAllDto VideoGetById(long id);
        public List<VideoGetAllDto> VideosCreatedByContentCreator(long id);

        Task<long> CreateVideo(VideoCreateCommand videocreateCommand);
        public Task<bool> UpdateVideoDetail(UpdateVideoByIdCommand update);
        public Task<bool> DeleteVideo(DeleteVideoByIdCommand delete);
    }
}
