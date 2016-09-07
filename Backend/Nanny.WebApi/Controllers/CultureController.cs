using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Nanny.Commands;
using Nanny.Queries;

namespace Nanny.WebApi.Controllers
{
    [AllowAnonymous]
    public class CultureController : ApiController
    {
        private readonly DomainCultureQuery _domainCultureQuery;
        private readonly CultureQuery _cultureQuery;
        private readonly SaveCommand _saveCommand;
        private readonly CustomerQuery _customerQuery;

        public CultureController(DomainCultureQuery domainCultureQuery, CultureQuery cultureQuery, SaveCommand saveCommand, CustomerQuery customerQuery)
        {
            _domainCultureQuery = domainCultureQuery;
            _cultureQuery = cultureQuery;
            _saveCommand = saveCommand;
            _customerQuery = customerQuery;
        }

        public async Task<IHttpActionResult> Get()
        {
            var langCultures = await _domainCultureQuery.Execute(Request.Headers.Referrer?.Authority);
            return Ok(langCultures);
        }

        public async Task<IHttpActionResult> Get(string id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var customer = await _customerQuery.Execute(User.Identity.Name);
                if (customer.Culture != null)
                {
                    return Ok(customer.Culture.Key);
                }
            }

            return Ok(Thread.CurrentThread.CurrentUICulture.Name);
        }

        [Authorize]
        public async Task<IHttpActionResult> Put(string id)
        {
            var customer = await _customerQuery.Execute(User.Identity.Name);
            customer.Culture = await _cultureQuery.Execute(id);
            await _saveCommand.Execute(customer);

            return Ok();
        }
    }
}
