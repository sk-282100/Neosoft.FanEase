#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class Login
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public short? RoleId { get; set; }
    }
}
