using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.Video.Command.Create;
using Neosoft.FAMS.Application.Features.Video.Commands.Delete;
using Neosoft.FAMS.Application.Features.Video.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [HttpPost]
        public async Task<IActionResult> Create(VideoCreateCommand videoCreateCommand)
        {
            var data = await _mediator.Send(videoCreateCommand);
            return Ok(data);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] long id)
        {
            var delete = new DeleteVideoByIdCommand { VideoId = id };
            var data = await _mediator.Send(delete);
            return Ok(data);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update([FromBody] UpdateVideoByIdCommand updateVideoByIdCommand)
        {           
            var data = await _mediator.Send(updateVideoByIdCommand);
            return Ok(data);
        }
    }
}
