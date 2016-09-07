using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Adwaer.Entity;

namespace Nanny.Domain.Entities.Localization
{
    public class LangResource : EntityBase<int>
    {
        public string Name { get;set; }
        [Required]
        public LangCulture Culture { get; set; }
        public ICollection<LangResourceValue> Values { get; set; } 
    }
}
