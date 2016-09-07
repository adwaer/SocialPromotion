using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Adwaer.Entity;
using Nanny.Contract;
using Nanny.Cqrs.Condition.Abstract;
using Nanny.Domain.Entities.Location;

namespace Nanny.Domain.Entities.Base
{
    [DataContract]
    public abstract class DictionaryEntity : EntityBase<int>, IHasName, IDictionaryEntity
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "order")]
        public int Order { get; set; }
        [DataMember(Name = "disabled")]
        public bool Disabled { get; set; }
        [DataMember(Name = "country")]
        [ForeignKey("OwnerCountry_Iso")]
        public virtual Country OwnerCountry { get; set; }
        [MaxLength(128)]
        public string OwnerCountry_Iso { get; set; }
    }
}
