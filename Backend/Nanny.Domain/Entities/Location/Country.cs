using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Nanny.Domain.Entities.Localization;

namespace Nanny.Domain.Entities.Location
{
    [DataContract]
    public class Country
    {
        public Country()
        {
        }

        public Country(string iso, string name)
        {
            Name = name;
            Iso = iso;
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [Key]
        [DataMember(Name = "iso")]
        [MaxLength(128)]
        public string Iso { get; set; }

        public ICollection<HttpDomain> HttpDomains { get; set; }
        public ICollection<LangCulture> LangCultures { get; set; }
    }
}
