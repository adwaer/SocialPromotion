using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    /// <summary>
    /// Профессиональные умения домработницы
    /// </summary>
    public class HousekeeperWorkingSkill : DictionaryEntity
    {
        public virtual ICollection<HousekeeperProfile> Profiles { get; set; }
    }
}