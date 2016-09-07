using System.Collections.Generic;
using System.Runtime.Serialization;
using Nanny.Domain.Entities.Location;

namespace Nanny.WebApi.ViewModel
{
    [DataContract]
    public class AddressViewModel
    {
        [DataMember(Name = "details")]
        public AddressDetailsViewModel Details { get; set; }
        [DataMember(Name = "apiresult")]
        public string ApiResult { get; set; }
        public Country Country { get; set; }
        [DataMember(Name = "units")]
        public IEnumerable<AddressUnitViewModel> UnitsAddressUnitViewModels { get; set; }
    }
}