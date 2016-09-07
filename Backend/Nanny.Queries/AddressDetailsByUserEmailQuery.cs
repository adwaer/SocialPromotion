using System.Data.Entity;
using System.Threading.Tasks;
using Nanny.Cqrs;
using Nanny.Domain.Entities;
using Nanny.Domain.Entities.Location;

namespace Nanny.Queries
{
    public class AddressDetailsByUserEmailQuery : IQuery<string, Task<AddressDetails>>
    {
        private readonly DbContext _dbContext;
        public AddressDetailsByUserEmailQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddressDetails> Execute(string email)
        {
            var account = await _dbContext
                .Set<SimpleCustomerAccount>()
                .Include(a => a.Customer.Address.Details)
                .FirstOrDefaultAsync(c => c.Email == email);

            return account?.Customer.Address.Details;
        }
    }
}
