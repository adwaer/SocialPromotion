using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Domain.Entities.Profiles
{
    [Table("NannyProfiles")]
    public class NannyProfile : WorkerProfile
    {
        /// <summary>
        /// Есть свои дети
        /// </summary>
        public bool HaveChildren { get; set; }
        /// <summary>
        /// Есть водительские права
        /// </summary>
        public bool HaveDriverLicense { get; set; }
        /// <summary>
        /// Есть свой автомобиль
        /// </summary>
        public bool HaveCar { get; set; }

        public virtual Liveinout Liveinout { get; set; }
        public virtual Employment Employment { get; set; }
        public virtual ChildrenCount ChildrenCount { get; set; }
        public virtual ICollection<NannyEducation> NannyEducations { get; set; }
        public virtual ICollection<NannyWorkingCondition> NannyWorkingConditions { get; set; }
        public virtual ICollection<WorkingExperienceAge> WorkingExperienceAges { get; set; }
        public virtual ICollection<NannyWorkingSkill> NannyWorkingSkills { get; set; }
        public virtual ICollection<AboutNanny> AboutNannies { get; set; }

    }
}
