using System;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class HealthCheckExecutionHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime On { get; set; }
        public int? HealthCheckExecutionId { get; set; }

        public virtual Execution HealthCheckExecution { get; set; }
    }
}
