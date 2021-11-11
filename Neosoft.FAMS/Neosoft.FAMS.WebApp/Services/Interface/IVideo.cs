using Neosoft.FAMS.Application.Features.Video.Command.Create;
using Neosoft.FAMS.Application.Features.Video.Commands.Delete;
using Neosoft.FAMS.Application.Features.Video.Commands.Update;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;
using System.Collections.Generic;
using System.Threading.Tasks;

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
