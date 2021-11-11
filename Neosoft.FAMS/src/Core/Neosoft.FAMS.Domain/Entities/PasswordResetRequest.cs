using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class PasswordResetRequest
    {
        [Key]
        public long RequestId { get; set; }
        public long? LoginId { get; set; }
        public DateTime? RequestedOn { get; set; }
        public string ValidCode { get; set; }
        public DateTime? ExpiredOn { get; set; }
    }
}
