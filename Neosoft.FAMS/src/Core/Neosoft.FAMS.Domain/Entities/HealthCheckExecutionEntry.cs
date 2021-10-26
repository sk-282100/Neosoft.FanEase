using System;
using System.Collections.Generic;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class HealthCheckExecutionEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public int? HealthCheckExecutionId { get; set; }
        public string Tags { get; set; }

        public virtual Execution HealthCheckExecution { get; set; }
    }
}
