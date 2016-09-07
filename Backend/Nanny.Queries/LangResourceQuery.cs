using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Nanny.Business;
using Nanny.Cqrs;
using Nanny.Domain.Entities.Localization;

namespace Nanny.Queries
{
    public class LangResourceQuery : IQuery<string, string, Task<Dictionary<string, string>>>
    {
        private readonly DbContext _dbContext;

        public LangResourceQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dictionary<string, string>> Execute(string resource, string culture)
        {
            if (culture == null)
            {
                culture = Thread.CurrentThread.CurrentUICulture.IetfLanguageTag;
            }

            var langRes = await _dbContext
                .Set<LangResourceValue>()
                .Where(c => c.LangResource.Name == resource && c.LangResource.Culture.Key == culture)
                .ToDictionaryAsync(r => r.Key, r => r.Value);

            var defaults = LangResourceDefaults.Get(resource, culture);
            foreach (var d in defaults)
            {
                if (!langRes.ContainsKey(d.Key))
                {
                    langRes.Add(d.Key, d.Value);
                }
            }

            return langRes;
        }
    }
}