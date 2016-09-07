using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class NannyEducationController : AbstractApi<NannyEducation>
    {
        public NannyEducationController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
