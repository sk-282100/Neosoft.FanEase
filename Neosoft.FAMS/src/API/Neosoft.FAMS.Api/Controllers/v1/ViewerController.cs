using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.Viewer.Commands.Create;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetById;
using Neosoft.FAMS.Application.Features.Viewer.Commands.Delete;
using Neosoft.FAMS.Application.Features.Viewer.Commands.Update;

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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] ViewerCreateCommand viewerCreateCommand)
        {
            var data = await _mediator.Send(viewerCreateCommand);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var viewerQuery = new ViewerQuery();
            var data = await _mediator.Send(viewerQuery);
            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAll([FromRoute] long id)
        {
            var viewerQuery = new GetViewerByIdQuery { ViewerId=id};
            var data = await _mediator.Send(viewerQuery);
            return Ok(data);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] long id)
        {
            var deleteQuery = new DeleteViewerByIdCommand { ViewerId = id };
            var data = await _mediator.Send(deleteQuery);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateById([FromBody]UpdateViewerCommand updateViewer)
        {
            var data = await _mediator.Send(updateViewer);
            return Ok(data);
        }
    }
}
