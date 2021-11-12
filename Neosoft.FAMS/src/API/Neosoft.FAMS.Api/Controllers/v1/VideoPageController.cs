using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.VideoPage.Commands.CheckClickId;
using Neosoft.FAMS.Application.Features.VideoPage.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoPageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VideoPageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update([FromBody] UpdateVideoPageByIdCommand updateVideoPageByIdCommand)
        {
            var data = await _mediator.Send(updateVideoPageByIdCommand);
            return Ok(data);
        }

        [HttpGet]
        [Route("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CheckClickId(long id)
        {
            CheckClickIdCommand checkClickId = new CheckClickIdCommand();
            checkClickId.id = id;
            var data = await _mediator.Send(checkClickId);
            if(data)
            {

            }
            else
            {

            }

            return Ok(data);
        }

    }
}

