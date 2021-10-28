using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.Video.Command.Create;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;
using Neosoft.FAMS.Application.Features.Video.Queries.GetById;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var videoQuery = new VideoGetAllCommand();
            var data = await _mediator.Send(videoQuery);
            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAll([FromRoute] long id)
        {
            var videoQuery = new VideoGetByIdCommand { VideoId = id };
            var data = await _mediator.Send(videoQuery);
            return Ok(data);
        }

    }
}
