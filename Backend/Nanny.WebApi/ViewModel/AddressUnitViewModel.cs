using System.Runtime.Serialization;
using Nanny.Enums;

namespace Nanny.WebApi.ViewModel
{
    [DataContract]
    public class AddressUnitViewModel
    {
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "shortname")]
        public string ShortName { get; set; }
        [DataMember(Name = "type")]
        public AddressUnitType Type { get; set; }
    }
}
