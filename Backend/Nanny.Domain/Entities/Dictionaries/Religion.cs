using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    /// <summary>
    /// Вероисповедание
    /// </summary>
    public class Religion : DictionaryEntity
    {
        public virtual ICollection<WorkerProfile> WorkerProfiles { get; set; }
    }
}
