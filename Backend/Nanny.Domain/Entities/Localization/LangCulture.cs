using System.Collections.Generic;
using System.Runtime.Serialization;
using Adwaer.Entity;
using Nanny.Domain.Entities.Dictionaries;
using Nanny.Domain.Entities.Location;

namespace Nanny.Domain.Entities.Localization
{
    [DataContract]
    public class LangCulture : EntityBase<int>
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }
        [DataMember(Name = "language")]
        public Language Language { get; set; }
        [IgnoreDataMember]
        public ICollection<Country> Countryes { get; set; }
    }
}
