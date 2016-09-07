using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    /// <summary>
    /// Количество детей
    /// </summary>
    public class ChildrenCount : DictionaryEntity
    {
        public virtual ICollection<NannyProfile> NannyProfiles { get; set; }
        public virtual ICollection<TutorProfile> TutorProfiles { get; set; }
    }
}
