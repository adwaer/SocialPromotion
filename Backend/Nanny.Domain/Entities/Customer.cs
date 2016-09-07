using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Adwaer.Entity;
using Nanny.Domain.Entities.Localization;
using Nanny.Domain.Entities.Location;
using Nanny.Domain.Entities.Profiles;
using Nanny.Enums;

namespace Nanny.Domain.Entities
{
    public class Customer : EntityBase<int>
    {
        public string DisplayName { get; set; }
        public WorkerType SearchType { get; set; }
        public DateTime? BirthDate { get; set; }
        
        public virtual LangCulture Culture { get; set; }

        [Required]
        public virtual Address Address { get; set; }
        public virtual WorkerProfile Profile { get; set; }
        public virtual ICollection<SimpleCustomerAccount> SimpleCutomerAccounts { get; set; }
    }
}
