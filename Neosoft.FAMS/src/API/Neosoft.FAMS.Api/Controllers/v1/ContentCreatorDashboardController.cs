using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.GetCreatorStatisticById;
using Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.GetYearlyStats;
using Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.TopVideo;

namespace Neosoft.FAMS.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentCreatorDashboardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContentCreatorDashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCreatorStats([FromRoute] long id)
        {
            var adminStats = new GetCreatorStatisticQuery{ ContentCreatorId = id };
            var data = await _mediator.Send(adminStats);
            return Ok(data);
        }

        [HttpGet]
        [Route("/VideoStatistics/{id}")]
        public async Task<IActionResult> GetCreatorVideoStats([FromRoute] long id)
        {
            var adminStats = new GetCreatorVideoStatisticQuery { ContentCreatorId= id};
            var data = await _mediator.Send(adminStats);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetYearlyStatistics/{id}")]
        public async Task<IActionResult> GetYearlyStatistics([FromRoute] long id,long years)
        {
            var yearlyStats = new GetYearlyStatisticQuery { ContentCreatorId = id,year = years };
            var data = await _mediator.Send(yearlyStats);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetTopVideos/{id}")]
        public async Task<IActionResult> GetTopVideos([FromRoute] long id)
        {
            var topVideos = new GetTopVideoQuery{ContentCreatorId = id};
            var data = await _mediator.Send(topVideos);
            return Ok(data);
        }
    }
}

