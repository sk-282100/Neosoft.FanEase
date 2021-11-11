using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.Template.Queries
{
    public class TemplateListDto
    {
        public long TemplateId { get; set; }
        public string TemplateName { get; set; }
        public bool? IsDeleted { get; set; }
        public string ThumbnailImage { get; set; }
        public short? TemplateType { get; set; }
        public bool? PublishStatus { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
