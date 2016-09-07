using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Nanny.Cqrs;
using Nanny.Domain.Dto;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Queries
{
    public class EducationQuery : IQuery<Task<DictionaryDto[]>>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly LangResourceSingleQuery _langResourceSingleQuery;

        public EducationQuery(DbContext dbContext, IMapper mapper, LangResourceSingleQuery langResourceSingleQuery)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _langResourceSingleQuery = langResourceSingleQuery;
        }

        public async Task<DictionaryDto[]> Execute()
        {
            var educations = (await _dbContext
                .Set<NannyEducation>()
                .Where(c => !c.Disabled)
                .ToArrayAsync())
                .Select(ed => _mapper.Map<DictionaryDto>(ed))
                .ToArray();

            foreach (var education in educations)
            {
                await LocalizeItem(education);
            }


            return educations;
        }

        private async Task LocalizeItem(DictionaryDto dic)
        {
            dic.Name = await _langResourceSingleQuery.Execute(dic.Name, Thread.CurrentThread.CurrentUICulture.IetfLanguageTag);
        }
    }
}