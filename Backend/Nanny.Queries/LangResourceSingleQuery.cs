using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Nanny.Business;
using Nanny.Cqrs;
using Nanny.Domain.Entities.Localization;

namespace Nanny.Queries
{
    public class LangResourceSingleQuery : IQuery<string, string, Task<string>>
    {
        private readonly DbContext _dbContext;

        public LangResourceSingleQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> Execute(string resource, string culture)
        {
            if (string.IsNullOrEmpty(culture))
                culture = Thread.CurrentThread.CurrentUICulture.IetfLanguageTag;


            var res = resource.Split('|');
            var reourceName = res[0];
            var reourceKey = res[1];

            var langRes = await _dbContext
                .Set<LangResourceValue>()
                .Where(c => c.LangResource.Name == reourceName && c.LangResource.Culture.Key == culture && c.Key == reourceKey)
                .FirstOrDefaultAsync();

            if (langRes == null)
            {
                var dictionary = LangResourceDefaults.Get(reourceName, culture);
                return dictionary[reourceKey];
            }

            return langRes.Value;
        }
    }
}