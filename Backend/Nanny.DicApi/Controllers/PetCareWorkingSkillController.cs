using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class PetCareWorkingSkillController : AbstractApi<PetCareWorkingSkill>
    {
        public PetCareWorkingSkillController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
