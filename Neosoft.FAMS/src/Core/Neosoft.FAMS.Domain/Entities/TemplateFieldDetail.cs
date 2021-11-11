using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class TemplateFieldDetail
    {
        [Key]
        public long TemplateFieldId { get; set; }
        public long? TemplateId { get; set; }
        public string TemplateFieldCode { get; set; }
    }
}
