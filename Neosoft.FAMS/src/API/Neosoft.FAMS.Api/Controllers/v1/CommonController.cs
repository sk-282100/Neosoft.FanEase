using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Neosoft.FAMS.Application.Features.Common.Queries.GetAllList;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;


        public CommonController(IMediator mediator, ILogger<CommonController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetCountryPhoneCode/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetPhoneCode([FromRoute]int id)
        {
            var phoneQuery = new GetPhoneCodeQuery(){countryId = id};
            var dtos = await _mediator.Send(phoneQuery);
            return Ok(dtos);

        }
        [HttpGet()]
        [Route("GetCountryList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCountryList()
        {
            _logger.LogInformation("GetCountryList Initiated");
            var dtos = await _mediator.Send(new GetAllCountryListQuery());
            _logger.LogInformation("GetCountryList Completed");
            return Ok(dtos);
        }
        [HttpGet()]
        [Route("GetStateList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetStateList(int countryId)
        {
            _logger.LogInformation("GetStateList Initiated");
            GetAllStateListQuery _getAllStateListQuery = new GetAllStateListQuery();
            _getAllStateListQuery.countryId = countryId;
            var dtos = await _mediator.Send(_getAllStateListQuery);
            _logger.LogInformation("GetStateList Completed");
            return Ok(dtos);
        }
        [HttpGet()]
        [Route("GetCityList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCityList(int stateId)
        {
            _logger.LogInformation("GetCityList Initiated");
            GetAllCityListQuery _getAllCityListQuery = new GetAllCityListQuery();
            _getAllCityListQuery.stateId = stateId;
            var dtos = await _mediator.Send(_getAllCityListQuery);
            _logger.LogInformation("GetCityList Completed");
            return Ok(dtos);
        }
    }
}
