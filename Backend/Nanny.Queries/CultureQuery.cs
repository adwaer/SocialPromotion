using System.Data.Entity;
using System.Threading.Tasks;
using Nanny.Cqrs;
using Nanny.Domain.Entities.Localization;

namespace Nanny.Queries
{
    public class CultureQuery : IQuery<string, Task<LangCulture>>
    {
        private readonly DbContext _dbContext;
        public CultureQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<LangCulture> Execute(string culture)
        {
            var lang = await _dbContext
                .Set<LangCulture>()
                .FirstOrDefaultAsync(c => c.Key == culture);

            return lang;
        }
    }
}
