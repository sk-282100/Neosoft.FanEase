using Neosoft.FAMS.Domain.Common;
using System;

namespace Neosoft.FAMS.Domain.Entities
{
    public class UserDemo : AuditableEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public bool IsAdmin { get; set; }

    }
}
