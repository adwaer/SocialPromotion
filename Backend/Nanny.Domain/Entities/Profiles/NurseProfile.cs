using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Domain.Entities.Profiles
{
    [Table("NurseProfiles")]
    public class NurseProfile : WorkerProfile
    {
        /// <summary>
        /// Есть водительские права
        /// </summary>
        public bool HaveDriverLicense { get; set; }
        /// <summary>
        /// Есть свой автомобиль
        /// </summary>
        public bool HaveCar { get; set; }
        public virtual ICollection<NurseEducation> NurseEducations { get; set; }
        public virtual ICollection<NurseWorkingCondition> NurseWorkingConditions { get; set; }
        public virtual ICollection<WorkingExperienceDiagnose> WorkingExperienceDiagnoses { get; set; }
        public virtual ICollection<NurseWorkingSkill> NurseWorkingSkills { get; set; }
        public virtual ICollection<AboutNurse> AboutNurses { get; set; }
        public virtual Liveinout Liveinout { get; set; }
        public virtual Employment Employment { get; set; }
    }
}
