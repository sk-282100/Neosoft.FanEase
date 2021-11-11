using System.ComponentModel.DataAnnotations;

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class States
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { get; set; }
    }
}
