using System;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public bool IsAdmin { get; set; }
    }
}
