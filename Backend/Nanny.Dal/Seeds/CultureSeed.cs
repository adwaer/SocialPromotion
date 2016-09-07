using System.Linq;
using Nanny.Domain.Entities.Localization;

namespace Nanny.Dal.Seeds
{
    internal class CultureSeed
    {
        private readonly DefaultCtx _context;

        public CultureSeed(DefaultCtx context)
        {
            _context = context;
        }

        public LangCulture GetCulture(string cultureName, string name)
        {
            return _context.LangCultures.FirstOrDefault(c => c.Key == cultureName)
                ?? _context.LangCultures.Local.FirstOrDefault(c => c.Key == cultureName);
            //if (culture == null)
            //{
            //    culture = new LangCulture
            //    {
            //        Key = cultureName,
            //        Language = _languageSeed.GetLanguage(name)
            //    };
            //    _context.LangCultures.Add(culture);
            //}

            //return culture;
        }

        public LangCulture Create(LanguageSeed languageSeed, string cultureName, string name)
        {
            var langCulture = _context.LangCultures.Create();

            langCulture.Key = cultureName;
            langCulture.Language = languageSeed.GetLanguage(name);

            return langCulture;
        }
    }
}