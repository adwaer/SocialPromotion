using System.Threading.Tasks;
using System.Web.Http;
using Nanny.Cqrs.Condition;
using Nanny.Queries;

namespace Nanny.WebApi.Controllers
{
    [AllowAnonymous]
    public class WorkersController : ApiController
    {
        private readonly WorkersQuery _workersQuery;
        private readonly AddressDetailsByUserEmailQuery _addressDetailsByUserEmailQuery;

        public WorkersController(WorkersQuery workersQuery, AddressDetailsByUserEmailQuery addressDetailsByUserEmailQuery)
        {
            _workersQuery = workersQuery;
            _addressDetailsByUserEmailQuery = addressDetailsByUserEmailQuery;
        }

        public async Task<IHttpActionResult> Get([FromUri]WorkersCriteria id)
        {
            if (RequestContext.Principal.Identity.IsAuthenticated
                && (!id.DistanceLat.HasValue || !id.DistanceLng.HasValue))
            {
                var addressDetails = await _addressDetailsByUserEmailQuery.Execute(RequestContext.Principal.Identity.Name);

                if (addressDetails != null)
                {
                    id.DistanceLat = addressDetails.Lat;
                    id.DistanceLng = addressDetails.Lng;
                }
            }

            if (id.Count <= 0)
            {
                id.Count = 100;
            }

            return Ok(await _workersQuery.Execute(id));
        }
    }
}
