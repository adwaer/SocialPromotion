using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class LiveinoutController : AbstractApi<Liveinout>
    {
        public LiveinoutController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
