using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    /// <summary>
    /// Опыт работы (диагнозы)
    /// </summary>
    public class WorkingExperienceDiagnose : DictionaryEntity
    {
        public virtual ICollection<NurseProfile> Profiles { get; set; }
    }
}
