using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    /// <summary>
    /// Проживание
    /// </summary>
    public class Liveinout : DictionaryEntity
    {
        public virtual ICollection<NannyProfile> NannyProfiles { get; set; }
        public virtual ICollection<NurseProfile> NurseProfiles { get; set; }
        public virtual ICollection<PetCareProfile> PetCareProfiles { get; set; }
        public virtual ICollection<HousekeeperProfile> HousekeeperProfiles { get; set; }
    }
}