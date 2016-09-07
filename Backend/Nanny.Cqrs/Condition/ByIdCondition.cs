using Adwaer.Entity;
using Nanny.Cqrs.Condition.Abstract;

namespace Nanny.Cqrs.Condition
{
    public class ByIdCondition<T> : ICondition<T> where T : IEntity<int>
    {
        private readonly int _id;

        public ByIdCondition(int id)
        {
            _id = id;
        }
        
        public bool Get(T entity)
        {
            return entity.Id.Equals(_id);
        }
    }
}
