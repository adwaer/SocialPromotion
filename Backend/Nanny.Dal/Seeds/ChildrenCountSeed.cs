using System.Linq;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Dal.Seeds
{
    internal class ChildrenCountSeed
    {
        private readonly DefaultCtx _context;

        public ChildrenCountSeed(DefaultCtx context)
        {
            _context = context;
        }

        public void Execute()
        {
            if (!_context.ChildrenCounts.Any())
            {
                _context.ChildrenCounts.Add(new ChildrenCount
                {
                    Disabled = false,
                    Name = "children_count|one"
                });
                _context.ChildrenCounts.Add(new ChildrenCount
                {
                    Disabled = false,
                    Name = "children_count|one_two"
                });
                _context.ChildrenCounts.Add(new ChildrenCount
                {
                    Disabled = false,
                    Name = "children_count|any"
                });
            }

        }
    }
}