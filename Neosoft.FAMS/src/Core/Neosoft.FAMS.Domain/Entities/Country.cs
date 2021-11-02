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
        public bool? IsActive { get; set; }
        public int? Sequence { get; set; }
        public string SortName { get; set; }
        public string PhoneCode { get; set; }
    }
}
