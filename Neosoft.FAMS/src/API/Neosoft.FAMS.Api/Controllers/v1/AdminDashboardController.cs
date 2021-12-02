using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetAll;
using Neosoft.FAMS.Application.Features.AdminDashboard.Queries.TopCampaign;
using Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetYearlyStatistics;
using Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetYearlyLiveStatistics;

namespace Neosoft.FAMS.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashboardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminDashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Author: Sana Haju
        /// Date: 25-11-2021
        /// Reason: Returns list of all counts(Videos,Advertisements,views,Clicks) of analysis.
        /// </summary>
        /// <returns>Returns list of all counts(Videos,Advertisements,views,Clicks) of analysis.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAdminStats()
        {
            var adminStats = new GetAdminStatisticQuery();
            var data = await _mediator.Send(adminStats);
            return Ok(data);
        }
        /// <summary>
        /// Author: Sana Haju
        /// Date: 25-11-2021
        /// Reason: Returns list of top videos(most Viewed,Clicked).
        /// </summary>
        /// <returns>Returns list of top videos(most Viewed,Clicked).</returns>
        [HttpGet]
        [Route("GetTopVideos")]
        public async Task<IActionResult> GetTopVideos()
        {
            var topVideos = new GetTopVideoQuery();
            var data = await _mediator.Send(topVideos);
            return Ok(data);
        }
        /// <summary>
        /// Author: Raj Bhosale
        /// Date: 26-11-2021
        /// Reason: Returns list of top Campaigns(most Viewed,Clicked).
        /// </summary>
        /// <returns>Returns list of top Campaigns(most Viewed,Clicked).</returns>
        [HttpGet]
        [Route("GetTopCampaign")]
        public async Task<IActionResult> GetTopCampaign() 
        {
            var topCampaign = new GetTopCampaignQuery();
            var data = await _mediator.Send(topCampaign);
            return Ok(data);

        }
        /// <summary>
        /// Author: Raj Bhosale
        /// Date: 26-11-2021
        /// Reason: Returns array of total videos uploaded by creators.
        /// </summary>
        /// <returns>Returns array of total videos uploaded by creators.</returns>
        [HttpGet]
        [Route("GetYearlyStatistics")]
        public async Task<IActionResult> GetYearlyStatistics(long years)
        {
            var yearlyStats = new GetYearlyStatisticsQuery { year = years };
            var data = await _mediator.Send(yearlyStats);
            return Ok(data);
        }
        /// <summary>
        /// Author: Raj Bhosale
        /// Date: 26-11-2021
        /// Reason: Returns array of total videos uploaded by creators(which is live).
        /// </summary>
        /// <returns>Returns array of total videos uploaded by creators(which is live).</returns>
        [HttpGet]
        [Route("GetYearlyLiveStatistics")]
        public async Task<IActionResult> GetYearlyLiveStatistics(long years)
        {
            var yearlyStats = new GetYearlyLiveStatisticsQuery { year = years };
            var data = await _mediator.Send(yearlyStats);
            return Ok(data);
        }
    }
}
