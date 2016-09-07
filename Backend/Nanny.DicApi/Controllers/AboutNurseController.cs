using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class AboutNurseController : AbstractApi<AboutNurse>
    {
        public AboutNurseController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
