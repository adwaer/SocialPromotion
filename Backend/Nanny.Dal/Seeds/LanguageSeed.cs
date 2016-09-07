using System;
using System.Linq;
using Nanny.Domain.Entities.Dictionaries;
using Nanny.Domain.Entities.Localization;

namespace Nanny.Dal.Seeds
{
    internal class LanguageSeed
    {
        private readonly DefaultCtx _context;

        public LanguageSeed(DefaultCtx context)
        {
            _context = context;
        }

        public void Execute()
        {
            if (!_context.Languages.Any())
            {
                var languages = GetLanguages();
                _context.Languages.AddRange(languages);
            }

            if (!_context.LangCultures.Any())
            {
                GetCulture("ru-RU", "languages|russian");
                GetCulture("en-US", "languages|english");
                GetCulture("en-CA", "languages|english");
                GetCulture("de-DE", "languages|german");
                GetCulture("fr-CA", "languages|french");
                GetCulture("fr-FR", "languages|french");
                GetCulture("es-ES", "languages|spanish");
                GetCulture("it-IT", "languages|italian");
                GetCulture("uk-UA", "languages|ukrainian");
                GetCulture("tt-RU", "languages|tatar");
                GetCulture("hy-AM", "languages|armenian");
                GetCulture("ka-GE", "languages|georgian");
                GetCulture("kk-KZ", "languages|kazakh");
                GetCulture("he-IL", "languages|hebrew");
                GetCulture("fi-FI", "languages|finnish");
                GetCulture("sv-FI", "languages|swedish");
            }
        }

        public LangCulture GetCulture(string cultureName, string name)
        {
            LangCulture culture = _context.LangCultures.FirstOrDefault(c => c.Key == cultureName)
                                  ?? _context.LangCultures.Local.FirstOrDefault(c => c.Key == cultureName);

            if (culture == null)
            {
                culture = _context.LangCultures.Create();
                culture.Key = cultureName;
                culture.Language = GetLanguage(name);
            }

            return culture;
        }

        public Language GetLanguage(string name)
        {
            var pattern = new Func<Language, bool>(c => c.Name == name);

            Language language = _context.Languages.FirstOrDefault(pattern)
                ?? _context.Languages.Local.FirstOrDefault(pattern)
                ?? GetLanguages().FirstOrDefault(pattern);

            return language;
        }

        private Language[] _languages;
        public Language[] GetLanguages()
        {
            if (_languages != null)
            {
                return _languages;
            }
            _languages = new[]
            {
                new Language { Name = "languages|russian", OwnerCountry_Iso = "RU" },
                new Language { Name = "languages|english",  OwnerCountry_Iso ="GB" },
                new Language { Name = "languages|german",  OwnerCountry_Iso ="DE" },
                new Language { Name = "languages|french", OwnerCountry_Iso ="FR" },
                new Language { Name = "languages|spanish", OwnerCountry_Iso ="ES" },
                new Language { Name = "languages|italian", OwnerCountry_Iso ="IT" },
                new Language { Name = "languages|ukrainian", OwnerCountry_Iso ="UA" },
                new Language { Name = "languages|tatar", OwnerCountry_Iso ="RU" },
                new Language { Name = "languages|armenian", OwnerCountry_Iso ="AM" },
                new Language { Name = "languages|georgian", OwnerCountry_Iso ="GE" },
                new Language { Name = "languages|kazakh",  OwnerCountry_Iso ="KZ" },
                new Language { Name = "languages|hebrew", OwnerCountry_Iso ="IL" },
                new Language { Name = "languages|finnish", OwnerCountry_Iso ="FI" },
                new Language { Name = "languages|swedish", OwnerCountry_Iso ="SE" }
            };

            return _languages;
        }
    }
}