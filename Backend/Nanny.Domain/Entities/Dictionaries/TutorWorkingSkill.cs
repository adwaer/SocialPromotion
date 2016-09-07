using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    /// <summary>
    /// Профессиональные умения репетитора
    /// </summary>
    public class TutorWorkingSkill : DictionaryEntity
    {
        public virtual ICollection<TutorProfile> TutorProfiles { get; set; }
    }
}