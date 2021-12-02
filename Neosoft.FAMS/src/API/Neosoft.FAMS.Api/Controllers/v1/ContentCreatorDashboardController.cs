using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.GetCreatorStatisticById;
using Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.GetYearlyLiveStatistics;
using Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.GetYearlyStats;
using Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.TopVideo;
using Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.TopCampaign;

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
        /// <summary>
        /// Author: Sana Haju
        /// Date: 22-11-2021
        /// Reason: To Get Creator Account Statistics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCreatorStats([FromRoute] long id)
        {
            var adminStats = new GetCreatorStatisticQuery{ ContentCreatorId = id };
            var data = await _mediator.Send(adminStats);
            return Ok(data);
        }


        /// <summary>
        /// Author: Sana Haju
        /// Date: 22-11-2021
        /// Reason: To Get Creator Video Statistics
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/VideoStatistics/{id}")]
        public async Task<IActionResult> GetCreatorVideoStats([FromRoute] long id)
        {
            var adminStats = new GetCreatorVideoStatisticQuery { ContentCreatorId= id};
            var data = await _mediator.Send(adminStats);
            return Ok(data);
        }

        /// <summary>
        /// Author: Sana Haju
        /// Date: 25-11-2021
        /// Reason: To Get Creator's Yearly Video Statistics 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="years"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetYearlyStatistics/{id}")]
        public async Task<IActionResult> GetYearlyStatistics([FromRoute] long id,long years)
        {
            var yearlyStats = new GetYearlyStatisticQuery { ContentCreatorId = id,year = years };
            var data = await _mediator.Send(yearlyStats);
            return Ok(data);
        }

        /// <summary>
        /// Author: Sana Haju
        /// Date: 25-11-2021
        /// Reason: To Get Creator's Top Videos 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTopVideos/{id}")]
        public async Task<IActionResult> GetTopVideos([FromRoute] long id)
        {
            var topVideos = new GetTopVideoQuery{ContentCreatorId = id};
            var data = await _mediator.Send(topVideos);
            return Ok(data);
        }


        /// <summary>
        /// Author: Sana Haju
        /// Date: 25-11-2021
        /// Reason: To Get Creator's Top Campaigns
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTopCampaign/{id}")]
        public async Task<IActionResult> GetTopCampaign([FromRoute] long id)
        {
            var topCampaign = new GetTopCampaignQuery{ContentCreatorId = id};
            var data = await _mediator.Send(topCampaign);
            return Ok(data);

        }

        /// <summary>
        /// Author: Sana Haju
        /// Date: 1-12-2021
        /// Reason:To Get Creator's Yearly Live Video Statistics 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="years"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetYearlyLiveStatistics/{id}")]
        public async Task<IActionResult> GetYearlyLiveStatistics([FromRoute] long id, long years)
        {
            var yearlyStats = new GetYearlyLiveStatisticQuery { ContentCreatorId = id, year = years };
            var data = await _mediator.Send(yearlyStats);
            return Ok(data);
        }
    }
}

