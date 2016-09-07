using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    /// <summary>
    /// Виды животных
    /// </summary>
    public class AnimalType : DictionaryEntity
    {
        public virtual ICollection<PetCareProfile> PetCareProfiles { get; set; }
    }
}
