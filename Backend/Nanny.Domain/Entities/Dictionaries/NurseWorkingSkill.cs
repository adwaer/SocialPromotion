using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    /// <summary>
    /// Профессиональные умения сиделки
    /// </summary>
    public class NurseWorkingSkill : DictionaryEntity
    {
        public virtual ICollection<NurseProfile> Profiles { get; set; }
    }
}