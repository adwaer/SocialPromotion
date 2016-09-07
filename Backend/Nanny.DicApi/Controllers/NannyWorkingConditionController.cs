using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class NannyWorkingConditionController : AbstractApi<NannyWorkingCondition>
    {
        public NannyWorkingConditionController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
