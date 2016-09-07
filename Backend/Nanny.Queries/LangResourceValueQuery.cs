using System.Data.Entity;
using System.Threading.Tasks;
using Nanny.Cqrs;
using Nanny.Domain.Entities.Localization;

namespace Nanny.Queries
{
    public class LangResourceValueQuery : IQuery<string, string, Task<LangResourceValue>>
    {
        private readonly DbContext _dbContext;

        public LangResourceValueQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LangResourceValue> Execute(string key, string localizedName)
        {
            return await _dbContext
                .Set<LangResourceValue>()
                .FirstOrDefaultAsync(v => v.LangResource.Name == key && v.Value == localizedName);
        }
    }
}
