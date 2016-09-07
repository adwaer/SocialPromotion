using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class NurseWorkingConditionController : AbstractApi<NurseWorkingCondition>
    {
        public NurseWorkingConditionController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
