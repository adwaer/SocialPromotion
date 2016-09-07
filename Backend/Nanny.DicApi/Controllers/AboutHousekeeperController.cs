using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class AboutHousekeeperController : AbstractApi<AboutHousekeeper>
    {
        public AboutHousekeeperController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
