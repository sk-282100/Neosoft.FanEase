using MediatR;
using Neosoft.FAMS.Application.Features.Template.Queries.GetAllById;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Template.Queries.GetAdvertisementByVideoId
{
    public class VideoAdvertisementByVideoIdQuery:IRequest<List<GetAllTemplateByIdDto>>
    {
        public long VideoId { get; set; }
    }
}
