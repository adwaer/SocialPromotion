using System.Runtime.Serialization;
using Nanny.Domain.Entities.Base;

namespace Nanny.Domain.Entities.Dictionaries
{
    [DataContract]
    public class Metro : DictionaryEntity
    {
        [DataMember(Name = "lat")]
        public double Lat { get; set; }
        [DataMember(Name = "lng")]
        public double Lng { get; set; }
    }
}
