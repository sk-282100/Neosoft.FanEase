using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.VideoPage.Commands.CheckClickId;
using Neosoft.FAMS.Application.Features.VideoPage.Commands.Update;
using Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllList;
using Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllVideoStatistics;
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
        public async Task<IActionResult> CheckClickId(long viewerId,long videoId)
        {
            CheckClickIdCommand checkClickId = new CheckClickIdCommand();
            checkClickId.viewerId = viewerId;
            checkClickId.videoId = videoId;
            var data = await _mediator.Send(checkClickId);
            return Ok(data);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCounters([FromRoute] long id)
        {
           
            GetAllVideoStaisticsQuery VideoQuery = new GetAllVideoStaisticsQuery();
            VideoQuery.id = id;
            var data = await _mediator.Send(VideoQuery);
            return Ok(data);
        }

        [HttpGet]
        [Route("/Likes/{id}")]

        public async Task<IActionResult> GetLikes([FromRoute] long id, long viewerId)
        {
            GetAndUpdateLikeQuery GetLikes = new GetAndUpdateLikeQuery();
            GetLikes.videoId = id;
            GetLikes.viewerId = viewerId;
            var data = await _mediator.Send(GetLikes);
            return Ok(data);
        }

        [HttpGet]
        [Route("/Dislikes/{id}")]

        public async Task<IActionResult> GetDislikes([FromRoute] long id, long viewerId)
        {
            GetAndUpdateDislikeQuery GetDislikes = new GetAndUpdateDislikeQuery();
            GetDislikes.videoId = id;
            GetDislikes.viewerId = viewerId;
            var data = await _mediator.Send(GetDislikes);
            return Ok(data);
        }

        [HttpGet]
        [Route("/Views/{id}")]

        public async Task<IActionResult> GetViews([FromRoute] long id, long viewerId)
        {
            GetAndUpdateViewsQuery GetViews = new GetAndUpdateViewsQuery();
            GetViews.videoId = id;
            GetViews.viewerId = viewerId;
            var data = await _mediator.Send(GetViews);
            return Ok(data);
        }

    }
}

