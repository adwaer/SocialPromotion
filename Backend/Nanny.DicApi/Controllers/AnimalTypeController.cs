using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class AnimalTypeController : AbstractApi<AnimalType>
    {
        public AnimalTypeController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
