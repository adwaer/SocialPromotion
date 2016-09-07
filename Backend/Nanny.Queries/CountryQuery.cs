using System.Data.Entity;
using System.Threading.Tasks;
using Nanny.Cqrs;
using Nanny.Domain.Entities.Location;

namespace Nanny.Queries
{
    public class CountryQuery : IQuery<string, Task<Country>>
    {
        private readonly DbContext _dbContext;
        public CountryQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Country> Execute(string iso)
        {
            return await _dbContext
                .Set<Country>()
                .FirstOrDefaultAsync(c => c.Iso == iso);
        }
    }
}
