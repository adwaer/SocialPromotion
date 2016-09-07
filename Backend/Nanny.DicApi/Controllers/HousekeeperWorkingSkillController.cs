using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class HousekeeperWorkingSkillController : AbstractApi<HousekeeperWorkingSkill>
    {
        public HousekeeperWorkingSkillController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
