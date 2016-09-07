using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Adwaer.Entity;
using Nanny.Enums;

namespace Nanny.Domain.Entities.Location
{
    public class Address : EntityBase<int>
    {
        [Required]
        public virtual AddressDetails Details { get; set; }
        [ForeignKey("Country_Iso")]
        public virtual Country Country { get; set; }
        public string Country_Iso { get; set; }
        public AddressUnit City => AddressUnits.FirstOrDefault(u => u.Type == AddressUnitType.Locality);
        public AddressUnit Street => AddressUnits.FirstOrDefault(u => u.Type == AddressUnitType.Route);
        public AddressUnit Home => AddressUnits.FirstOrDefault(u => u.Type == AddressUnitType.StreetNumber);
        public AddressUnit Postal => AddressUnits.FirstOrDefault(u => u.Type == AddressUnitType.PostalCode);
        public AddressUnit AdministrativeAreaLevel1 => AddressUnits.FirstOrDefault(u => u.Type == AddressUnitType.AdministrativeAreaLevel1);
        public string ApiResult { get; set; }
        public virtual ICollection<AddressUnit> AddressUnits { get; set; }
    }
}
