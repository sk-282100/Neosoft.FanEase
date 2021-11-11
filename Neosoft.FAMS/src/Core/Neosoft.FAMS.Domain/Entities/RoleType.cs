using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class RoleType
    {
        [Key]
        public short RoleId { get; set; }
        public string RoleType1 { get; set; }
        public bool? IsActive { get; set; }
    }
}
