using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetAll;

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

        [HttpGet]
        public async Task<IActionResult> GetAdminStats()
        {
            var adminStats = new GetAdminStatisticQuery();
            var data = await _mediator.Send(adminStats);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetTopVideos")]
        public async Task<IActionResult> GetTopVideos()
        {
            var topVideos = new GetTopVideoQuery();
            var data = await _mediator.Send(topVideos);
            return Ok(data);
        }

    }
}
