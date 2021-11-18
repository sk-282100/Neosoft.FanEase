using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetTopViewsVideo;
using Neosoft.FAMS.Application.Features.Viewer.Commands.Create;
using Neosoft.FAMS.Application.Features.Viewer.Commands.Delete;
using Neosoft.FAMS.Application.Features.Viewer.Commands.Update;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetByEmail;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetById;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ViewerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Author:Raj Bhosale,Kajal Padhiyar
        /// Date:25/10/2021
        /// Reason:It will Create new Viewer
        /// </summary>
        /// <param name="viewerCreateCommand"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] ViewerCreateCommand viewerCreateCommand)
        {
            var data = await _mediator.Send(viewerCreateCommand);
            return Ok(data);
        }
        /// <summary>
        /// Author:Raj Bhosale,Kajal Padhiyar
        /// Date:25/10/2021
        /// Reason:It will Get All Viewer's List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var viewerQuery = new ViewerQuery();
            var data = await _mediator.Send(viewerQuery);
            return Ok(data);
        }
        /// <summary>
        /// Author:Raj Bhosale,Kajal Padhiyar
        /// Date:25/10/2021
        /// Reason:It will Get Details of Specific Viewer Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAll([FromRoute] long id)
        {
            var viewerQuery = new GetViewerByIdQuery { ViewerId = id };
            var data = await _mediator.Send(viewerQuery);
            return Ok(data);
        }
        /// <summary>
        /// Author:Raj Bhosale,Kajal Padhiyar
        /// Date:25/10/2021
        /// Reason: It will Delete Viewer by a Specific Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] long id)
        {
            var deleteQuery = new DeleteViewerByIdCommand { ViewerId = id };
            var data = await _mediator.Send(deleteQuery);
            return Ok(data);
        }
        /// <summary>
        /// Author:Raj Bhosale,Kajal Padhiyar
        /// Date:25/10/2021
        /// Reason: It will Update Viewer by Id
        /// </summary>
        /// <param name="updateViewer"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateById([FromBody] UpdateViewerCommand updateViewer)
        {
            var data = await _mediator.Send(updateViewer);
            return Ok(data);
        }

        [HttpGet]
        [Route("getViewerByEmail")]
        public async Task<IActionResult> GetByEmail([FromQuery] string username)
        {
            var Email = username.Split('?');
            var viewerQuery = new GetViewerByEmailQuery { Username = Email[0] };
            var data = await _mediator.Send(viewerQuery);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetTopLikes")]
        public async Task<IActionResult> GetTopLikes()
        {
            var topVideos = new GetTopLikesVideoListQuery();
            var data = await _mediator.Send(topVideos);
            return Ok(data);
        }

    }
}
