using System.ComponentModel.DataAnnotations;
using Adwaer.Entity;

namespace Nanny.Domain.Entities.Localization
{
    public class LangResourceValue : EntityBase<int>
    {
        public string Key { get; set; }
        public string Value { get; set; }
        [Required]
        public LangResource LangResource { get; set; }
    }
}