using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    public class HousekeeperWorkingCondition : DictionaryEntity
    {
        public virtual ICollection<HousekeeperProfile> Profiles { get; set; }
    }
}
