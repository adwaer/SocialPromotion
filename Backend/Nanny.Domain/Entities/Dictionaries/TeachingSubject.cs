using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    /// <summary>
    /// Преподаваемые предметы
    /// </summary>
    public class TeachingSubject : DictionaryEntity
    {
        public virtual ICollection<TutorProfile> TutorProfiles { get; set; }
    }
}
