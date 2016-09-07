using System.Linq;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Dal.Seeds
{
    internal class EmploymentSeed
    {
        private readonly DefaultCtx _context;

        public EmploymentSeed(DefaultCtx context)
        {
            _context = context;
        }

        public void Execute()
        {
            if (!_context.Employments.Any())
            {
                _context.Employments.Add(new Employment
                {
                    Disabled = false,
                    Name = "employment|full"
                });
                _context.Employments.Add(new Employment
                {
                    Disabled = false,
                    Name = "employment|part"
                });
                _context.Employments.Add(new Employment
                {
                    Disabled = false,
                    Name = "employment|full_or_part"
                });
            }

        }
    }
}