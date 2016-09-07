using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;
using Nanny.Enums;

namespace Nanny.Domain.Entities.Dictionaries
{
    /// <summary>
    /// Язык
    /// </summary>
    public class Language : DictionaryEntity
    {
        public virtual ICollection<WorkerProfile> WorkerProfiles { get; set; }
    }
}
