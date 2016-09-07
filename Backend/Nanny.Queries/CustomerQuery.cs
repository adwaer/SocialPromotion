using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Nanny.Cqrs;
using Nanny.Domain.Entities;

namespace Nanny.Queries
{
    public class CustomerQuery : IQuery<string, Task<Customer>>
    {
        private readonly DbContext _dbContext;

        public CustomerQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> Execute(string email)
        {
            return await _dbContext
                .Set<Customer>()
                .Include(c => c.Address.Country)
                .Include(c => c.SimpleCutomerAccounts)
                .Include(c => c.Culture)
                .FirstOrDefaultAsync(c => c.SimpleCutomerAccounts.Any(a => a.Email == email));
        }

    }
}
