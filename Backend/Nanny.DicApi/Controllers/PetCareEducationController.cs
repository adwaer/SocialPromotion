using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class PetCareEducationController : AbstractApi<PetCareEducation>
    {
        public PetCareEducationController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
