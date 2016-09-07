using Nanny.Contract;
using Nanny.Cqrs.Condition.Abstract;

namespace Nanny.Cqrs.Condition
{
    public class ByNameCondition<T> : ICondition<T> where T : IHasName
    {
        public ByNameCondition(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public bool Get(T entity)
        {
            return entity.Name == Name;
        }
    }
}
