using MediatR;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.Orders.Queries.GetOrdersForMonth;
using System;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet(Name = "GetOrdersForMonth")]
        public async Task<ActionResult> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            var getOrdersForMonthQuery = new GetOrdersForMonthQuery() { Date = date, Page = page, Size = size };
            var dtos = await _mediator.Send(getOrdersForMonthQuery);
            return Ok(dtos);
        }
    }
}
