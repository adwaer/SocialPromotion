using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Nanny.Cqrs;
using Nanny.Domain.Entities.Localization;
using Nanny.Infrastructure;

namespace Nanny.Queries
{
    public class DomainCultureQuery : IQuery<string, Task<LangCulture[]>>
    {
        private readonly DbContext _dbContext;
        private readonly TypeCache<DomainCultureQuery, string, LangCulture[]> _typeCache;
        private readonly LangResourceSingleQuery _langResourceSingleQuery;

        public DomainCultureQuery(DbContext dbContext, TypeCache<DomainCultureQuery, string, LangCulture[]> typeCache, LangResourceSingleQuery langResourceSingleQuery)
        {
            _dbContext = dbContext;
            _typeCache = typeCache;
            _langResourceSingleQuery = langResourceSingleQuery;
        }

        public async Task<LangCulture[]> Execute(string domain)
        {
            var langCultures = _typeCache.Get(domain);
            if (langCultures != null)
            {
                return langCultures;
            }

            langCultures = await _dbContext
                .Set<LangCulture>()
                .Include(lc => lc.Language)
                .Where(lc => lc.Countryes.Any(c => c.HttpDomains.Any(d => d.Name == domain)))
                .ToArrayAsync();

            if (!langCultures.Any())
            {
                langCultures = await _dbContext
                    .Set<LangCulture>()
                    .Include(lc => lc.Language)
                    .Where(lc => lc.Countryes.Any(c => c.HttpDomains.Any(d => d.Name == null)))
                    .ToArrayAsync();
            }
            
            foreach (var langCulture in langCultures)
            {
                await LocalizeItem(langCulture);
            }
            
            _typeCache.Set(domain, langCultures);
            return langCultures;
        }

        private async Task LocalizeItem(LangCulture langCulture)
        {
            langCulture.Language.Name = await _langResourceSingleQuery.Execute(langCulture.Language.Name, Thread.CurrentThread.CurrentUICulture.IetfLanguageTag);
        }
    }
}
