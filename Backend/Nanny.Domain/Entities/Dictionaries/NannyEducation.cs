using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    public class NannyEducation : DictionaryEntity
    {
        public virtual ICollection<NannyProfile> NannyProfiles { get; set; }
    }
}
