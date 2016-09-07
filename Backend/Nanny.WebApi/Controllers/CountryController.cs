using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using Nanny.Queries;

namespace Nanny.WebApi.Controllers
{
    [AllowAnonymous]
    public class CountryController : ApiController
    {
        private readonly CustomerQuery _customerQuery;
        private readonly DomainQuery _domainQuery;

        public CountryController(CustomerQuery customerQuery, DomainQuery domainQuery)
        {
            _customerQuery = customerQuery;
            _domainQuery = domainQuery;
        }

        public async Task<IHttpActionResult> Get()
        {
            if (User.Identity.IsAuthenticated)
            {
                var customer = await _customerQuery.Execute(User.Identity.Name);
                return Ok(customer.Address.Country);
            }

            var domains = _domainQuery.Execute(Request.Headers.Referrer?.Authority);
            return Ok((await domains.FirstAsync()).Country);
        }
    }
}
