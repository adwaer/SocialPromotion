namespace Nanny.Cqrs.Condition.Abstract
{
    public interface ICondition<in T>
    {
        bool Get(T entity);
    }
}
