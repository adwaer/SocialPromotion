using System.Linq;
using Nanny.Domain.Entities;

namespace Nanny.Dal.Seeds
{
    internal class HttpDomainSeed
    {
        private readonly DefaultCtx _context;

        public HttpDomainSeed(DefaultCtx context)
        {
            _context = context;
        }

        public void Execute()
        {
            if (!_context.HttpDomains.Any())
            {
                _context.HttpDomains.Add(new HttpDomain
                {
                    Name = null,
                    Country_Iso = "RU"
                });
                _context.HttpDomains.Add(new HttpDomain
                {
                    Name = "test.nashanyanya.ru",
                    Country_Iso = "RU",
                });
                _context.HttpDomains.Add(new HttpDomain
                {
                    Name = "finland.nashanyanya.ru",
                    Country_Iso = "FI",
                });
                _context.HttpDomains.Add(new HttpDomain
                {
                    Name = "canada.nashanyanya.ru",
                    Country_Iso = "CA"
                });
            }
            else
            {
                SetCountry(null, "RU");
                SetCountry("test.nashanyanya.ru", "RU");
                SetCountry("finland.nashanyanya.ru", "FI");
                SetCountry("canada.nashanyanya.ru", "CA");
            }
        }

        private void SetCountry(string domain, string iso)
        {
            var defaultDomain = _context.HttpDomains.First(d => d.Name == domain);
            defaultDomain.Country_Iso = iso;
        }
    }
}