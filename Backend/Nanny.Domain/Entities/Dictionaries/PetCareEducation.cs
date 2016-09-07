using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    public class PetCareEducation : DictionaryEntity
    {
        public virtual ICollection<PetCareProfile> PetCareProfiles { get; set; }
    }
}
