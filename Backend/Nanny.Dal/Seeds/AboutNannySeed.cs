using System.Linq;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Dal.Seeds
{
    internal class AboutNannySeed
    {
        private readonly DefaultCtx _context;

        public AboutNannySeed(DefaultCtx context)
        {
            _context = context;
        }

        public void Execute()
        {
            bool clear = false;
            if (_context.AboutNannies.Any(l => l.Name == "aboutme|first"))
            {
                _context.AboutNannies.RemoveRange(_context.AboutNannies);
                clear = true;
            }

            if (!_context.AboutNannies.Any() || clear)
            {
                _context.AboutNannies.Add(new AboutNanny
                {
                    Disabled = false,
                    Name = "aboutnanny|first",
                    Order = 0
                });
                _context.AboutNannies.Add(new AboutNanny
                {
                    Disabled = false,
                    Name = "aboutnanny|second",
                    Order = 1
                });
                _context.AboutNannies.Add(new AboutNanny
                {
                    Disabled = false,
                    Name = "aboutnanny|third",
                    Order = 2
                });
                _context.AboutNannies.Add(new AboutNanny
                {
                    Disabled = false,
                    Name = "aboutnanny|fourth",
                    Order = 3
                });
            }

        }
    }
}