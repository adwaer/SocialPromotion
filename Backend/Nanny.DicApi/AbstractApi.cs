using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using Nanny.Cqrs.Condition;
using Nanny.Cqrs.Condition.Abstract;
using Nanny.Cqrs.Query;

namespace Nanny.DicApi
{
    [AllowAnonymous]
    public abstract class AbstractApi<T> : ApiController where T : class, IDictionaryEntity
    {
        private readonly SimpleQuery _simpleQuery;

        protected AbstractApi(SimpleQuery simpleQuery)
        {
            _simpleQuery = simpleQuery;
        }

        public async Task<IHttpActionResult> Get(DictionaryEntityCondition<T> condition)
        {
            var data = await _simpleQuery
                .Execute(condition)
                .ToArrayAsync();

            return Ok(data);
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var data = await _simpleQuery
                .Execute(new ByIdCondition<T>(id))
                .FirstOrDefaultAsync();

            return Ok(data);
        }
    }
}