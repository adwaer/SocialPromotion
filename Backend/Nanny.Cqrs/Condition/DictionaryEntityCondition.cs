using Nanny.Contract;
using Nanny.Cqrs.Condition.Abstract;

namespace Nanny.Cqrs.Condition
{
    public class DictionaryEntityCondition<T> : ICondition<T> where T : IDictionaryEntity
    {
        private readonly IDictionaryEntity _dictionaryEntity;

        public DictionaryEntityCondition(IDictionaryEntity dictionaryEntity)
        {
            _dictionaryEntity = dictionaryEntity;
        }

        public bool Get(T entity)
        {
            return (string.IsNullOrEmpty(_dictionaryEntity.Name) ||  entity.Name == _dictionaryEntity.Name)
                && (string.IsNullOrEmpty(_dictionaryEntity.OwnerCountry_Iso) || entity.OwnerCountry_Iso == _dictionaryEntity.OwnerCountry_Iso);
        }
    }
}
