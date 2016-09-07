using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    /// <summary>
    /// Профессиональные умения зооняни
    /// </summary>
    public class PetCareWorkingSkill : DictionaryEntity
    {
        public virtual ICollection<PetCareProfile> PetCareProfiles { get; set; }
    }
}