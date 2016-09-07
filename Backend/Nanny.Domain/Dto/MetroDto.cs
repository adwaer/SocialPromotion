using System.Runtime.Serialization;

namespace Nanny.Domain.Dto
{
    [DataContract]
    public class MetroDto
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "lat")]
        public double Lat { get; set; }
        [DataMember(Name = "lng")]
        public double Lng { get; set; }
    }
}
