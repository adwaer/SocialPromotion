using System.Data.Entity;
using System.Linq;
using Nanny.Cqrs;
using Nanny.Domain.Entities;

namespace Nanny.Queries
{
    public class DomainQuery : IQuery<string, IQueryable<HttpDomain>>
    {
        private readonly DbContext _dbContext;
        public DomainQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IQueryable<HttpDomain> Execute(string domain)
        {
            var domains = _dbContext
                .Set<HttpDomain>()
                .Where(d => d.Name == domain);

            if (!domains.Any())
            {
                domains = _dbContext
                    .Set<HttpDomain>()
                    .Where(d => d.Name == null);
            }

            return domains;
        }
    }
}
