using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.Template.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TemplateController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Author:Aman Sharma,Kajal Padhiyar<br></br>
        /// Date:11/11/2021<br></br>
        /// Reason:It Will Get All Template List
        /// </summary>
        /// <returns>List of All Templates</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var templateList = new GetTemplateListQuery();
            var data = await _mediator.Send(templateList);
            return Ok(data);
        }
    }
}
