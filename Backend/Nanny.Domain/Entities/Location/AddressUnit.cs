using System.Collections.Generic;
using Adwaer.Entity;
using Nanny.Enums;

namespace Nanny.Domain.Entities.Location
{
    public class AddressUnit : EntityBase<int>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public AddressUnitType Type { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
