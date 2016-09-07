using System.Linq;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Dal.Seeds
{
    internal class AboutNurseSeed
    {
        private readonly DefaultCtx _context;

        public AboutNurseSeed(DefaultCtx context)
        {
            _context = context;
        }

        public void Execute()
        {

            if (!_context.AboutNurses.Any())
            {
                _context.AboutNurses.Add(new AboutNurse
                {
                    Disabled = false,
                    Name = "aboutnurse|first",
                    Order = 0
                });
                _context.AboutNurses.Add(new AboutNurse
                {
                    Disabled = false,
                    Name = "aboutnurse|second",
                    Order = 1
                });
                _context.AboutNurses.Add(new AboutNurse
                {
                    Disabled = false,
                    Name = "aboutnurse|third",
                    Order = 2
                });
                _context.AboutNurses.Add(new AboutNurse
                {
                    Disabled = false,
                    Name = "aboutnurse|fourth",
                    Order = 3
                });
            }

        }
    }
}