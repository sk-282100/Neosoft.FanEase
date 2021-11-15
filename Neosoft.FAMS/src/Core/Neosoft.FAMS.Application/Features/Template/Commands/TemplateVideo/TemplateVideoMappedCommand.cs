using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Neosoft.FAMS.Application.Features.Template.Commands.TemplateVideo
{
    public class TemplateVideoMappedCommand : IRequest<long>
    {
        public long TemplateFieldId { get; set; }
        public long? VideoId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
