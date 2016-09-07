using System.Linq;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.Dal.Seeds
{
    internal class ReligionSeed
    {
        private readonly DefaultCtx _context;

        public ReligionSeed(DefaultCtx context)
        {
            _context = context;
        }

        public void Execute()
        {
            if (!_context.Religions.Any())
            {
                _context.Religions.Add(new Religion
                {
                    Disabled = false,
                    Name = "worship|atheist"
                });
                _context.Religions.Add(new Religion
                {
                    Disabled = false,
                    Name = "worship|orthodox"
                });
                _context.Religions.Add(new Religion
                {
                    Disabled = false,
                    Name = "worship|catholic"
                });
                _context.Religions.Add(new Religion
                {
                    Disabled = false,
                    Name = "worship|christia"
                });
                _context.Religions.Add(new Religion
                {
                    Disabled = false,
                    Name = "worship|muslim"
                });
                _context.Religions.Add(new Religion
                {
                    Disabled = false,
                    Name = "worship|buddhist"
                });
                _context.Religions.Add(new Religion
                {
                    Disabled = false,
                    Name = "worship|other"
                });
            }

        }
    }
}