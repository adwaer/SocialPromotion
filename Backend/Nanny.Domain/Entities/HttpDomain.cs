using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Adwaer.Entity;
using Nanny.Domain.Entities.Location;

namespace Nanny.Domain.Entities
{
    [DataContract]
    public class HttpDomain : EntityBase<int>
    {
        public string Name { get; set; }
        [ForeignKey("Country_Iso")]
        public virtual Country Country { get; set; }
        [DataMember(Name = "country_iso")]
        public string Country_Iso { get; set; }
    }
}
