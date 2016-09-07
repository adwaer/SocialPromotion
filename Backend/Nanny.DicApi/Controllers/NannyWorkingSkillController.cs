using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class NannyWorkingSkillController : AbstractApi<NannyWorkingSkill>
    {
        public NannyWorkingSkillController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
