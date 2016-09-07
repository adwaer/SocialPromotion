using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class MetroController : AbstractApi<Metro>
    {
        public MetroController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
