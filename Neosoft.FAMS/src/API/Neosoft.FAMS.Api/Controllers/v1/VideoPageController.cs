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
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCounters([FromRoute] long id)
        {
            var LikeCounter = 0;
            var DisLikeCounter = 0;
            var ShareCounter = 0;
            var ViewCounter = 0;
            GetAllVideoStaisticsQuery VideoQuery = new GetAllVideoStaisticsQuery();
            VideoQuery.id = id;
            var data = await _mediator.Send(VideoQuery);
            
            if (data != null)
            {
                foreach(var i in data)
                {
                    if (i.IsLiked == true)
                        LikeCounter += 1;
                    else if (i.IsLiked == false)
                        DisLikeCounter = 0;
                    if (i.IsShared == true)
                        ShareCounter += 1;
                    if (i.IsViewed == true)
                        ViewCounter += 1;
                }
              
                //return Ok(LikeCounter,DisLikeCounter,ShareCounter,ViewCounter);
            }
            return Ok(data);
        }

        [HttpGet]
        [Route("/Likes/{id}")]

        public async Task<IActionResult> GetLikes([FromRoute] long id)
        {
            GetAndUpdateLikeQuery GetLikes = new GetAndUpdateLikeQuery();
            GetLikes.videoId = id;
            var data = await _mediator.Send(GetLikes);
            return Ok(data);
        }

    }
}

