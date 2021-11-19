﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neosoft.FAMS.Application.Features.Template.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.Template.Commands.TemplateVideo;
using Neosoft.FAMS.Application.Features.Template.Queries.GetAdvertisementByVideoId;
using Neosoft.FAMS.Application.Features.Template.Queries.GetAllById;
using Neosoft.FAMS.Application.Features.Template.Queries.GetById;

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
        [HttpGet]
        [Route("VideoAdvertisementByVideoId{id}")]
        public async Task<IActionResult> VideoAdvertisementByVideoId([FromRoute] long id)
        {

            var template = new VideoAdvertisementByVideoIdQuery() { VideoId = id };
            var data = await _mediator.Send(template);
            return Ok(data);
        }
        /// <summary>
        /// Author:Aman Sharma,Kajal Padhiyar<br></br>
        /// Date:11/11/2021<br></br>
        /// Reason:It Will Get All Template List
        /// </summary>
        /// <returns>List of All Templates</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]long id)
        {

            var template = new GetTemplateByIdQuery(){TemplateId = id};
            var data = await _mediator.Send(template);
            return Ok(data);
        }

        /// <summary>
        /// Author:Aman Sharma<br></br>
        /// Date:15/11/2021<br></br>
        /// Reason:It Will Add Template-Video Mapping data
        /// </summary>
        /// <returns>Id of new record</returns>
        [HttpPost]
        public async Task<IActionResult> AddTemplateVideoData(TemplateVideoMappedCommand mappedCommand)
        {
            long id = await _mediator.Send(mappedCommand);
            return Ok(id);
        }

        /// <summary>
        /// Author:Aman Sharma,Kajal Padhiyar<br></br>
        /// Date:15/11/2021<br></br>
        /// Reason:It Will Get All Template List
        /// </summary>
        /// <returns>List of All Templates</returns>
        [HttpGet]
        [Route("GetAllTemplate")]
        public async Task<IActionResult> GetAllTemplate()
        {
            var templateQuery = new GetAllTemplateListByIdQuery();
            var data = await _mediator.Send(templateQuery);
            return Ok(data);
        }
    }
}
