using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Domain.Entities.Profiles
{
    [Table("PetcareProfiles")]
    public class PetCareProfile : WorkerProfile
    {
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
        public virtual ICollection<PetCareEducation> PetCareEducations { get; set; }
        public virtual ICollection<PetCareWorkingSkill> PetCareWorkingSkills { get; set; }
        public virtual ICollection<AnimalType> AnimalTypes { get; set; }
    }
}
