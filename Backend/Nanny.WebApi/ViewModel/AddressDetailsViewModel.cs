using System.Runtime.Serialization;

namespace Nanny.WebApi.ViewModel
{
    [DataContract]
    public class AddressDetailsViewModel
    {
        [DataMember(Name = "components")]
        public string Components { get; set; }
        [DataMember(Name = "lat")]
        public double Lat { get; set; }
        [DataMember(Name = "lng")]
        public double Lng { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
        [DataMember(Name = "detailsId")]
        public string DetailsId { get; set; }
        [DataMember(Name = "placeId")]
        public string PlaceId { get; set; }
        [DataMember(Name = "reference")]
        public string Reference { get; set; }
        [DataMember(Name = "scope")]
        public string Scope { get; set; }
        [DataMember(Name = "types")]
        public string Types { get; set; }
        [DataMember(Name = "utcOffset")]
        public string UtcOffset { get; set; }
    }
}
