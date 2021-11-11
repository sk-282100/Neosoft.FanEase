#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class Configuration
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public string Name { get; set; }
        public string DiscoveryService { get; set; }
    }
}
