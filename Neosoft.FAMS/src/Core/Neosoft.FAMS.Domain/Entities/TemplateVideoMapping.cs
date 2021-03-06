using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class TemplateVideoMapping
    {
        [Key]
        public long TemplateVideoMappingId { get; set; }
        public long TemplateFieldId { get; set; }
        public long? VideoId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
