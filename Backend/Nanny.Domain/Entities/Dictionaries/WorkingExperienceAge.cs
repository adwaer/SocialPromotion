using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    /// <summary>
    /// Опыт работы (возраст детей)
    /// </summary>
    public class WorkingExperienceAge : DictionaryEntity
    {
        public virtual ICollection<NannyProfile> NannyProfiles { get; set; }
        public virtual ICollection<TutorProfile> TutorProfiles { get; set; }
    }
}
