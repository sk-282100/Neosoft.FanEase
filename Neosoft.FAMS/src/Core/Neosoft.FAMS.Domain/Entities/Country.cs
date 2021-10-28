using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class Country
    {
        [Key]
        public long CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
