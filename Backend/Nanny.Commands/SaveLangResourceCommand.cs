using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using Nanny.Cqrs;
using Nanny.Cqrs.Condition;
using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;
using Nanny.Domain.Entities.Localization;
using Nanny.Queries;

namespace Nanny.Commands
{
    public class SaveLangResourceCommand : ICommand<string, string>
    {
        private readonly LangResourceValueQuery _langResourceValueQuery;
        private readonly SimpleQuery _simpleQuery;
        private readonly DbContext _dbContext;

        public SaveLangResourceCommand(LangResourceValueQuery langResourceValueQuery, SimpleQuery simpleQuery, DbContext dbContext)
        {
            _langResourceValueQuery = langResourceValueQuery;
            _simpleQuery = simpleQuery;
            _dbContext = dbContext;
        }

        public async Task Execute(string resource, string value)
        {
            var strings = resource.Split('|');
            var res = strings[0];
            var key = strings[1];

            var langRes = await _dbContext
                .Set<LangResourceValue>()
                .Include(l => l.LangResource)
                .FirstOrDefaultAsync(
                    c =>
                        c.LangResource.Name == res &&
                        c.LangResource.Culture.Key == Thread.CurrentThread.CurrentUICulture.IetfLanguageTag &&
                        c.Key == key);
            //?? new LangResourceValue
            //{
            //    Key = key,
            //    Value = value,
            //    LangResource = await _dbContext
            //.Set<LangResource>()
            //.FirstAsync(
            //    lr =>
            //        lr.Culture.Key == Thread.CurrentThread.CurrentUICulture.IetfLanguageTag &&
            //        lr.Name == res)
            //};

            if (langRes == null)
            {
                var langResource = await _dbContext
                    .Set<LangResource>()
                    .FirstOrDefaultAsync(
                        lr =>
                            lr.Culture.Key == Thread.CurrentThread.CurrentUICulture.IetfLanguageTag &&
                            lr.Name == res);

                if (langResource == null)
                {
                    var langCulture = await _dbContext
                        .Set<LangCulture>()
                        .FirstOrDefaultAsync(c => c.Key == Thread.CurrentThread.CurrentUICulture.IetfLanguageTag);

                    if (langCulture == null)
                    {
                        var langResourceValue =
                            await
                                _langResourceValueQuery.Execute("languages",
                                    Thread.CurrentThread.CurrentUICulture.DisplayName.Split(' ')[0]);
                        langCulture = new LangCulture
                        {
                            Key = Thread.CurrentThread.CurrentUICulture.IetfLanguageTag,
                            Language = await _simpleQuery.Execute(new ByNameCondition<Language>(langResourceValue.Value)).FirstOrDefaultAsync()
                        };
                    }

                    langResource = new LangResource
                    {
                        Culture = langCulture,
                        Name = res
                    };
                }

                langRes = new LangResourceValue
                {
                    Key = key,
                    Value = value,
                    LangResource = langResource
                };
                _dbContext.Set<LangResourceValue>().Add(langRes);
            }

            langRes.Value = value;
            await _dbContext
                .SaveChangesAsync();
        }
    }
}