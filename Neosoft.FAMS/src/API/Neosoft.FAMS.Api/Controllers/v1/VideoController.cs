using MediatR;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.Video.Command.Create;
using Neosoft.FAMS.Application.Features.Video.Commands.Delete;
using Neosoft.FAMS.Application.Features.Video.Commands.Update;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;
using Neosoft.FAMS.Application.Features.Video.Queries.GetById;
using Neosoft.FAMS.Application.Features.Video.Queries.GetCreatedById;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.Video.Queries.GetVideoOfCreatorById;

namespace Neosoft.FAMS.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Author:Raj Bhosale
        /// Date:25/10/2021
        /// Reason: Adding Video with Details
        /// </summary>
        /// <param name="videoCreateCommand"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(VideoCreateCommand videoCreateCommand)
        {
            var data = await _mediator.Send(videoCreateCommand);
            return Ok(data);
        }
        /// <summary>
        /// Author:Raj Bhosale
        /// Date:25/10/2021
        /// Reason: Deleting By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] long id)
        {
            var delete = new DeleteVideoByIdCommand { VideoId = id };
            var data = await _mediator.Send(delete);
            return Ok(data);
        }
        /// <summary>
        /// Author:Raj Bhosale
        /// Date:25/10/2021
        /// Reason: Update Video By Id
        /// </summary>
        /// <param name="updateVideoByIdCommand"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update([FromBody] UpdateVideoByIdCommand updateVideoByIdCommand)
        {
            var data = await _mediator.Send(updateVideoByIdCommand);
            return Ok(data);
        }
        /// <summary>
        /// Author:Raj Bhosale
        /// Date:25/10/2021
        /// Reason: Getting All Video List 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var videoQuery = new VideoGetAllCommand();
            var data = await _mediator.Send(videoQuery);
            return Ok(data);
        }
        /// <summary>
        /// Author:Raj Bhosale
        /// Date:25/10/2021
        /// Reason:Getting Video By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAll([FromRoute] long id)
        {
            var videoQuery = new VideoGetByIdCommand { VideoId = id };
            var data = await _mediator.Send(videoQuery);
            return Ok(data);
        }
        /// <summary>
        /// Author: Raj Bhosale
        /// Date:27/10/2021
        /// Reason: To Get All Videos of specific Creators
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [Route(("Videos/{id}"))]
        public async Task<IActionResult> GetVideosofCreator([FromRoute] long id)
        {
            var videoQuery = new VideoGetCreatedByIdQuery { CreatedById = id };
            var data = await _mediator.Send(videoQuery);
            return Ok(data);
        }

        /// <summary>
        /// Author: Kajal Padhiyar,Aman Sharma
        /// Date:16/11/2021
        /// Reason: To Get All Videos of specific Creators
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(("CreatorVideosById/{id}"))]
        public async Task<IActionResult> GetCreatorVideoListById([FromRoute] long id)
        {
            var videoQuery = new GetVideoOfCreatorQuery { CreatedBy = id };
            var data = await _mediator.Send(videoQuery);
            return Ok(data);
        }

    }
}
