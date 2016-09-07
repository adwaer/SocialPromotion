using System.Linq;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Dal.Seeds
{
    internal class WorkingTermsSeed
    {
        private readonly DefaultCtx _context;

        public WorkingTermsSeed(DefaultCtx context)
        {
            _context = context;
        }

        public void Execute()
        {
            if (!_context.WorkingTerms.Any())
            {
                _context.WorkingTerms.Add(new WorkingTerm
                {
                    Disabled = false,
                    Name = "working_terms|long_time"
                });
                _context.WorkingTerms.Add(new WorkingTerm
                {
                    Disabled = false,
                    Name = "working_terms|season"
                });
                _context.WorkingTerms.Add(new WorkingTerm
                {
                    Disabled = false,
                    Name = "working_terms|necessity"
                });
            }

        }
    }
}