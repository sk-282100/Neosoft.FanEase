using System;
using System.Collections.Generic;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class TemplateFieldDetail
    {
        public long? TemplateId { get; set; }
        public long TemplateFieldId { get; set; }
        public string TemplateFieldCode { get; set; }
    }
}
