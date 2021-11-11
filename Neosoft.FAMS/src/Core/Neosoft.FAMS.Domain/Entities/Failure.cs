using System;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class Failure
    {
        public int Id { get; set; }
        public string HealthCheckName { get; set; }
        public DateTime LastNotified { get; set; }
        public bool IsUpAndRunning { get; set; }
    }
}
