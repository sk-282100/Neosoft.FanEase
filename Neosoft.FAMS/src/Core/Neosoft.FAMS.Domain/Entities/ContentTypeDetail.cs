using System;
using System.Collections.Generic;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class ContentTypeDetail
    {
        public short ContentTypeId { get; set; }
        public string ContentType { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
