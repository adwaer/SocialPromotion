using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class AboutNannyController : AbstractApi<AboutNanny>
    {
        public AboutNannyController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
