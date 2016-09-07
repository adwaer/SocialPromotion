using Adwaer.Identity;
using Nanny.Domain.Entities;
using Nanny.Queries;

namespace Nanny.WebApi.Identity
{
    public class OnCreateUserAction : IOnCreateUserAction<SimpleCustomerAccount>
    {
        private readonly CultureQuery _cultureQuery;

        public OnCreateUserAction(CultureQuery cultureQuery)
        {
            _cultureQuery = cultureQuery;
        }

        public async void Execute(SimpleCustomerAccount user)
        {
            user.Customer = user.Customer ?? new Customer();
            user.Customer.DisplayName = user.UserName;
            if (user.Customer.Culture == null)
            {
                user.Customer.Culture =
                    await _cultureQuery.Execute(System.Threading.Thread.CurrentThread.CurrentUICulture.Name);
            }
        }
    }
}
