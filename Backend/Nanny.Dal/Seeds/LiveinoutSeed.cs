using System.Linq;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Dal.Seeds
{
    internal class LiveinoutSeed
    {
        private readonly DefaultCtx _context;

        public LiveinoutSeed(DefaultCtx context)
        {
            _context = context;
        }

        public void Execute()
        {
            bool clear = false;
            if (_context.Liveinouts.Any(l => l.Name == "residence|with"))
            {
                _context.Liveinouts.RemoveRange(_context.Liveinouts);
                clear = true;
            }

            if (!_context.Liveinouts.Any() || clear)
            {
                _context.Liveinouts.Add(new Liveinout
                {
                    Disabled = false,
                    Name = "liveinout|with"
                });
                _context.Liveinouts.Add(new Liveinout
                {
                    Disabled = false,
                    Name = "liveinout|with_or_without"
                });
                _context.Liveinouts.Add(new Liveinout
                {
                    Disabled = false,
                    Name = "liveinout|without"
                });
            }

        }
    }
}