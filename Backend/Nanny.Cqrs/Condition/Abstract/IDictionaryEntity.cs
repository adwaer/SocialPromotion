using Adwaer.Entity;

namespace Nanny.Cqrs.Condition.Abstract
{
    public interface IDictionaryEntity: IEntity<int>
    {
        string Name { get; set; }
        string OwnerCountry_Iso { get; set; }
    }
}