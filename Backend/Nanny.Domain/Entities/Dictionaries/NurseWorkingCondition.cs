﻿using System.Collections.Generic;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Profiles;

namespace Nanny.Domain.Entities.Dictionaries
{
    public class NurseWorkingCondition : DictionaryEntity
    {
        public virtual ICollection<NurseProfile> Profiles { get; set; }
    }
}
