using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class EmploymentController : AbstractApi<Employment>
    {
        public EmploymentController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
