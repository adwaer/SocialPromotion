using System.Linq;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Dal.Seeds
{
    internal class AboutHousekeeperSeed
    {
        private readonly DefaultCtx _context;

        public AboutHousekeeperSeed(DefaultCtx context)
        {
            _context = context;
        }

        public void Execute()
        {
            if (!_context.AboutHousekeepers.Any())
            {
                _context.AboutHousekeepers.Add(new AboutHousekeeper
                {
                    Disabled = false,
                    Name = "abouthousekeeper|first",
                    Order = 0
                });
                _context.AboutHousekeepers.Add(new AboutHousekeeper
                {
                    Disabled = false,
                    Name = "abouthousekeeper|second",
                    Order = 1
                });
                _context.AboutHousekeepers.Add(new AboutHousekeeper
                {
                    Disabled = false,
                    Name = "abouthousekeeper|third",
                    Order = 2
                });
            }

        }
    }
}