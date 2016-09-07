using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class NurseWorkingSkillController : AbstractApi<NurseWorkingSkill>
    {
        public NurseWorkingSkillController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
