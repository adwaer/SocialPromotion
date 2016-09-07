using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class HousekeeperWorkingConditionController : AbstractApi<HousekeeperWorkingCondition>
    {
        public HousekeeperWorkingConditionController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
