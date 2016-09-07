using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class TeachingSubjectController : AbstractApi<TeachingSubject>
    {
        public TeachingSubjectController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
