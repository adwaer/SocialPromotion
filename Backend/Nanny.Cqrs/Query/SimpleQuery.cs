using System.Data.Entity;
using System.Linq;
using Nanny.Cqrs.Condition.Abstract;

namespace Nanny.Cqrs.Query
{
    public class SimpleQuery : IQuery
    {
        private readonly DbContext _dbContext;

        public SimpleQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Execute<T>(ICondition<T> condition) where T : class,  IDictionaryEntity
        {
            return _dbContext
                .Set<T>()
                .Where(x => condition.Get(x));
        }
    }
}
