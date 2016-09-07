using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Domain.Entities.Profiles
{
    [Table("TutorProfiles")]
    public class TutorProfile : WorkerProfile
    {
        /// <summary>
        /// Есть свои дети
        /// </summary>
        public bool HaveChildren { get; set; }

        public virtual ChildrenCount ChildrenCount { get; set; }
        public virtual ICollection<TutorEducation> TutorEducations { get; set; }
        public virtual ICollection<WorkingExperienceAge> WorkingExperienceAges { get; set; }
        public virtual ICollection<TeachingSubject> TeachingSubjects { get; set; }
        public virtual ICollection<TutorWorkingSkill> TutorWorkingSkills { get; set; }
    }
}
