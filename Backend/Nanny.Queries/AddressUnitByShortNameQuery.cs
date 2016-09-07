using System.Data.Entity;
using System.Threading.Tasks;
using Nanny.Cqrs;
using Nanny.Domain.Entities.Location;
using Nanny.Enums;

namespace Nanny.Queries
{
    public class AddressUnitByShortNameQuery : IQuery<string, AddressUnitType, Task<AddressUnit>>
    {
        private readonly DbContext _dbContext;

        public AddressUnitByShortNameQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddressUnit> Execute(string cityName, AddressUnitType type)
        {
            return await _dbContext
                .Set<AddressUnit>()
                .FirstOrDefaultAsync(c => c.Name == cityName && c.Type == type);
        }
    }
}
