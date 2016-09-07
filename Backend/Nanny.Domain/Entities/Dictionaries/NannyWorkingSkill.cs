using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    /// <summary>
    /// Профессиональные умения няни
    /// </summary>
    public class NannyWorkingSkill : DictionaryEntity
    {
        public virtual ICollection<NannyProfile> Profiles { get; set; }
    }
}
