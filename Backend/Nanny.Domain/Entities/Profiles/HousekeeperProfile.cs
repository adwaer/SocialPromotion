using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Domain.Entities.Profiles
{
    [Table("HousekeeperProfiles")]
    public class HousekeeperProfile : WorkerProfile
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
        public virtual ICollection<HousekeeperWorkingCondition> HousekeeperWorkingConditions { get; set; }
        public virtual ICollection<HousekeeperWorkingSkill> HousekeeperWorkingSkills { get; set; }
        public virtual ICollection<AboutHousekeeper> AboutHousekeepers { get; set; }
    }
}
