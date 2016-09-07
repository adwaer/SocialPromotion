using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class ReligionController : AbstractApi<Religion>
    {
        public ReligionController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
