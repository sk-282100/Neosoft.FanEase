using System;
using System.Collections.Generic;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class RoleType
    {
        public short RoleId { get; set; }
        public string RoleType1 { get; set; }
        public bool? IsActive { get; set; }
    }
}
