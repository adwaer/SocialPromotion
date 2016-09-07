using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Adwaer.Entity;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Domain.Entities.Profiles
{
    [Table("WorkerProfiles")]
    public class WorkerProfile : EntityBase<int>
    {
        /// <summary>
        /// Количество лет опыта
        /// </summary>
        public int YearExperience { get; set; }

        /// <summary>
        /// Дата начала работы
        /// </summary>
        public int WorkStartExperience { get; set; }
        /// <summary>
        /// Минимальная оплата в час
        /// </summary>
        public int Salary { get; set; }
        /// <summary>
        /// Дата начала работы
        /// </summary>
        public DateTime WorkStartDate { get; set; }
        /// <summary>
        /// Гражданство РФ
        /// </summary>
        public bool Citizenship { get; set; }
        /// <summary>
        /// Право на работу в РФ
        /// </summary>
        public bool RightToWork { get; set; }
        /// <summary>
        /// Не курю
        /// </summary>
        public bool NotSmoke { get; set; }

        public virtual Religion Religion { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<WorkingTerm> WorkingTerms { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool Disabled { get; set; }
    }
}
