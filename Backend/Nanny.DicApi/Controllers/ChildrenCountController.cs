using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class ChildrenCountController : AbstractApi<ChildrenCount>
    {
        public ChildrenCountController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
