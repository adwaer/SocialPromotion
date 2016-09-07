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
    public class MetroesQuery : IQuery<Task<MetroDto[]>>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly LangResourceSingleQuery _langResourceSingleQuery;

        public MetroesQuery(DbContext dbContext, IMapper mapper, LangResourceSingleQuery langResourceSingleQuery)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _langResourceSingleQuery = langResourceSingleQuery;
        }

        public async Task<MetroDto[]> Execute()
        {
            var metroes = (await
                _dbContext
                    .Set<Metro>()
                    .ToArrayAsync()
                )
                .Select(_mapper.Map<MetroDto>);

            var metroDtos = metroes as MetroDto[] ?? metroes.ToArray();
            foreach (var metro in metroDtos)
            {
                await LocalizeItem(metro);
            }

            return metroDtos.ToArray();
        }

        private async Task LocalizeItem(MetroDto metro)
        {
            metro.Name = await _langResourceSingleQuery.Execute(metro.Name, Thread.CurrentThread.CurrentUICulture.IetfLanguageTag);
        }
    }
}
