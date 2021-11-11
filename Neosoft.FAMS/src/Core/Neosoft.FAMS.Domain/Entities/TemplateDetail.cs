using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class TemplateDetail
    {
        [Key]
        public long TemplateId { get; set; }
        public string TemplateName { get; set; }
        public bool? IsDeleted { get; set; }
        public string ThumbnailImage { get; set; }
        public short? TemplateType { get; set; }
        public bool? PublishStatus { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
