using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class City
    {
        [Key]
        public long CityId { get; set; }
        public string CityName { get; set; }
        public long? CountryId { get; set; }
    }
}
