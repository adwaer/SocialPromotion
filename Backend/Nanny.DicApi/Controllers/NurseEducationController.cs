using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class NurseEducationController : AbstractApi<NurseEducation>
    {
        public NurseEducationController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
