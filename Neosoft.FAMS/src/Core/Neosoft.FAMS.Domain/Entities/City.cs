using System;
using System.Collections.Generic;

#nullable disable

namespace Neosoft.FAMS.Domain.Entities
{
    public partial class City
    {
        public long CityId { get; set; }
        public string CityName { get; set; }
        public long? CountryId { get; set; }
    }
}
