using System;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class RefreshToken
    {
        public string ApplicationUserId { get; set; }
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Revoked { get; set; }

        public virtual AspNetUser ApplicationUser { get; set; }
    }
}
