using System.Collections.Generic;
using System.Linq;
using Nanny.Domain.Entities.Localization;
using Nanny.Domain.Entities.Location;

namespace Nanny.Dal.Seeds
{
    internal class ContrySeed
    {
        private readonly DefaultCtx _context;
        private readonly CultureSeed _cultureSeed;
        private readonly LanguageSeed _languageSeed;

        public ContrySeed(DefaultCtx context, CultureSeed cultureSeed, LanguageSeed languageSeed)
        {
            _context = context;
            _cultureSeed = cultureSeed;
            _languageSeed = languageSeed;
        }
        
        public void Execute()
        {
            if (!_context.Countries.Any())
            {
                var countries = GetCountries();
                _context.Countries.AddRange(countries);

                foreach (var metro in _context.Metroes)
                {
                    metro.OwnerCountry_Iso = "RU";
                }

                foreach (var address in _context.Addresses.Include("Details"))
                {
                    address.Country_Iso = "RU";
                }

                foreach (var domain in _context.HttpDomains)
                {
                    domain.Country_Iso = "RU";
                }
            }
        }

        private static Country[] _countries;

        private Country[] GetCountries()
        {
            if (_countries != null)
            {
                return _countries;
            }

            _countries = new[]
            {
                new Country("AW", "Aruba"),
                new Country("AG", "Antigua and Barbuda"),
                new Country("AE", "United Arab Emirates"),
                new Country("AF", "Afghanistan"),
                new Country("DZ", "Algeria"),
                new Country("AZ", "Azerbaijan"),
                new Country("AL", "Albania"),
                new Country("AM", "Armenia"),
                new Country("AD", "Andorra"),
                new Country("AO", "Angola"),
                new Country("AS", "American Samoa"),
                new Country("AR", "Argentina"),
                new Country("AU", "Australia"),
                new Country("AT", "Austria"),
                new Country("AI", "Anguilla"),
                new Country("AX", "Åland Islands"),
                new Country("AQ", "Antarctica"),
                new Country("BH", "Bahrain"),
                new Country("BB", "Barbados"),
                new Country("BW", "Botswana"),
                new Country("BM", "Bermuda"),
                new Country("BE", "Belgium"),
                new Country("BS", "Bahamas, The"),
                new Country("BD", "Bangladesh"),
                new Country("BZ", "Belize"),
                new Country("BA", "Bosnia and Herzegovina"),
                new Country("BO", "Bolivia"),
                new Country("MM", "Myanmar"),
                new Country("BJ", "Benin"),
                new Country("BY", "Belarus"),
                new Country("SB", "Solomon Islands"),
                new Country("BR", "Brazil"),
                new Country("BT", "Bhutan"),
                new Country("BG", "Bulgaria"),
                new Country("BV", "Bouvet Island"),
                new Country("BN", "Brunei"),
                new Country("BI", "Burundi"),
                new Country("CA", "Canada")
                {
                    LangCultures = new List<LangCulture>
                    {
                        _cultureSeed.GetCulture("en-CA", "languages|english") ??
                        _cultureSeed.Create(_languageSeed, "en-CA", "languages|english"),
                        _cultureSeed.GetCulture("fr-CA", "languages|french") ??
                        _cultureSeed.Create(_languageSeed, "fr-CA", "languages|french")
                    }
                },
                new Country("KH", "Cambodia"),
                new Country("TD", "Chad"),
                new Country("LK", "Sri Lanka"),
                new Country("CG", "Congo, Republic of the"),
                new Country("CD", "Congo, Democratic Republic of the"),
                new Country("CN", "China"),
                new Country("CL", "Chile"),
                new Country("KY", "Cayman Islands"),
                new Country("CC", "Cocos (Keeling) Islands"),
                new Country("CM", "Cameroon"),
                new Country("KM", "Comoros"),
                new Country("CO", "Colombia"),
                new Country("MP", "Northern Mariana Islands"),
                new Country("CR", "Costa Rica"),
                new Country("CF", "Central African Republic"),
                new Country("CU", "Cuba"),
                new Country("CV", "Cape Verde"),
                new Country("CK", "Cook Islands"),
                new Country("CY", "Cyprus"),
                new Country("DK", "Denmark"),
                new Country("DJ", "Djibouti"),
                new Country("DM", "Dominica"),
                new Country("UM", "Jarvis  Island"),
                new Country("DO", "Dominican Republic"),
                new Country("EC", "Ecuador"),
                new Country("EG", "Egypt"),
                new Country("IE", "Ireland"),
                new Country("GQ", "Equatorial Guinea"),
                new Country("EE", "Estonia"),
                new Country("ER", "Eritrea"),
                new Country("SV", "El Salvador"),
                new Country("ET", "Ethiopia"),
                new Country("CZ", "Czech Republic"),
                new Country("GF", "French Guiana"),
                new Country("FI", "Finland")
                {
                    LangCultures = new List<LangCulture>
                    {
                        _cultureSeed.GetCulture("fi-FI", "languages|finnish") ??
                        _cultureSeed.Create(_languageSeed, "fi-FI", "languages|finnish"),
                        _cultureSeed.GetCulture("sv-FI", "languages|swedish") ??
                        _cultureSeed.Create(_languageSeed, "sv-FI", "languages|swedish")
                    }
                },
                new Country("FJ", "Fiji"),
                new Country("FK", "Falkland Islands (Islas Malvinas)"),
                new Country("FM", "Micronesia, Federated States of"),
                new Country("FO", "Faroe Islands"),
                new Country("PF", "French Polynesia"),
                new Country("UM", "Baker  Island"),
                new Country("FR", "France"),
                new Country("TF", "French Southern and Antarctic Lands"),
                new Country("GM", "Gambia, The"),
                new Country("GA", "Gabon"),
                new Country("GE", "Georgia"),
                new Country("GH", "Ghana"),
                new Country("GI", "Gibraltar"),
                new Country("GD", "Grenada"),
                new Country("GL", "Greenland"),
                new Country("DE", "Germany"),
                new Country("GP", "Guadeloupe"),
                new Country("GU", "Guam"),
                new Country("GR", "Greece"),
                new Country("GT", "Guatemala"),
                new Country("GN", "Guinea"),
                new Country("GY", "Guyana"),
                new Country("HT", "Haiti"),
                new Country("HK", "Hong Kong"),
                new Country("HM", "Heard Island and McDonald Islands"),
                new Country("HN", "Honduras"),
                new Country("UM", "Howland Island"),
                new Country("HR", "Croatia"),
                new Country("HU", "Hungary"),
                new Country("IS", "Iceland"),
                new Country("ID", "Indonesia"),
                new Country("IM", "Isle of Man"),
                new Country("IN", "India"),
                new Country("IO", "British Indian Ocean Territory"),
                new Country("IR", "Iran"),
                new Country("IL", "Israel"),
                new Country("IT", "Italy"),
                new Country("CI", "Cote d\"Ivoire"),
                new Country("IQ", "Iraq"),
                new Country("JP", "Japan"),
                new Country("JE", "Jersey"),
                new Country("JM", "Jamaica"),
                new Country("JO", "Jordan"),
                new Country("UM", "Johnston Atoll"),
                new Country("KE", "Kenya"),
                new Country("KG", "Kyrgyzstan"),
                new Country("KP", "Korea, North"),
                new Country("UM", "Kingman  Reef"),
                new Country("KI", "Kiribati"),
                new Country("KR", "Korea, South"),
                new Country("CX", "Christmas Island"),
                new Country("KW", "Kuwait"),
                new Country("KV", "Kosovo"),
                new Country("KZ", "Kazakhstan"),
                new Country("LA", "Laos"),
                new Country("LB", "Lebanon"),
                new Country("LV", "Latvia"),
                new Country("LT", "Lithuania"),
                new Country("LR", "Liberia"),
                new Country("SK", "Slovakia"),
                new Country("UM", "Palmyra  Atoll"),
                new Country("LI", "Liechtenstein"),
                new Country("LS", "Lesotho"),
                new Country("LU", "Luxembourg"),
                new Country("LY", "Libyan Arab"),
                new Country("MG", "Madagascar"),
                new Country("MQ", "Martinique"),
                new Country("MO", "Macau"),
                new Country("MD", "Moldova, Republic of"),
                new Country("YT", "Mayotte"),
                new Country("MN", "Mongolia"),
                new Country("MS", "Montserrat"),
                new Country("MW", "Malawi"),
                new Country("ME", "Montenegro"),
                new Country("MK", "The Former Yugoslav Republic of Macedonia"),
                new Country("ML", "Mali"),
                new Country("MC", "Monaco"),
                new Country("MA", "Morocco"),
                new Country("MU", "Mauritius"),
                new Country("UM", "Midway  Islands"),
                new Country("MR", "Mauritania"),
                new Country("MT", "Malta"),
                new Country("OM", "Oman"),
                new Country("MV", "Maldives"),
                new Country("MX", "Mexico"),
                new Country("MY", "Malaysia"),
                new Country("MZ", "Mozambique"),
                new Country("NC", "New Caledonia"),
                new Country("NU", "Niue"),
                new Country("NF", "Norfolk Island"),
                new Country("NE", "Niger"),
                new Country("VU", "Vanuatu"),
                new Country("NG", "Nigeria"),
                new Country("NL", "Netherlands"),
                new Country("NO", "Norway"),
                new Country("NP", "Nepal"),
                new Country("NR", "Nauru"),
                new Country("SR", "Suriname"),
                new Country("AN", "Netherlands Antilles"),
                new Country("NI", "Nicaragua"),
                new Country("NZ", "New Zealand"),
                new Country("PY", "Paraguay"),
                new Country("PN", "Pitcairn Islands"),
                new Country("PE", "Peru"),
                new Country("PK", "Pakistan"),
                new Country("PL", "Poland"),
                new Country("PA", "Panama"),
                new Country("PT", "Portugal"),
                new Country("PG", "Papua New Guinea"),
                new Country("PW", "Palau"),
                new Country("GW", "Guinea-Bissau"),
                new Country("QA", "Qatar"),
                new Country("RE", "Reunion"),
                new Country("RS", "Serbia"),
                new Country("MH", "Marshall Islands"),
                new Country("MF", "Saint Martin"),
                new Country("RO", "Romania"),
                new Country("PH", "Philippines"),
                new Country("PR", "Puerto Rico"),
                new Country("RU", "Russia")
                {
                    LangCultures = new List<LangCulture>
                    {
                        _cultureSeed.GetCulture("ru-RU", "languages|russian") ??
                        _cultureSeed.Create(_languageSeed, "ru-RU", "languages|russian"),
                        _cultureSeed.GetCulture("en-US", "languages|english") ??
                        _cultureSeed.Create(_languageSeed, "en-US", "languages|english")
                    }
                },
                new Country("RW", "Rwanda"),
                new Country("SA", "Saudi Arabia"),
                new Country("PM", "Saint Pierre and Miquelon"),
                new Country("KN", "Saint Kitts and Nevis"),
                new Country("SC", "Seychelles"),
                new Country("ZA", "South Africa"),
                new Country("SN", "Senegal"),
                new Country("SH", "Saint Helena"),
                new Country("SI", "Slovenia"),
                new Country("SL", "Sierra Leone"),
                new Country("SM", "San Marino"),
                new Country("SG", "Singapore"),
                new Country("SO", "Somalia"),
                new Country("ES", "Spain"),
                new Country("LC", "Saint Lucia"),
                new Country("SD", "Sudan"),
                new Country("SJ", "SVALBARD AND JAN MAYEN ISLANDS"),
                new Country("SE", "Sweden"),
                new Country("GS", "South Georgia and the Islands"),
                new Country("SY", "Syrian Arab Republic"),
                new Country("CH", "Switzerland"),
                new Country("TT", "Trinidad and Tobago"),
                new Country("TH", "Thailand"),
                new Country("TJ", "Tajikistan"),
                new Country("TC", "Turks and Caicos Islands"),
                new Country("TK", "Tokelau"),
                new Country("TO", "Tonga"),
                new Country("TG", "Togo"),
                new Country("ST", "Sao Tome and Principe"),
                new Country("TN", "Tunisia"),
                new Country("TL", "East Timor"),
                new Country("TR", "Turkey"),
                new Country("TV", "Tuvalu"),
                new Country("TW", "Taiwan"),
                new Country("TM", "Turkmenistan"),
                new Country("TZ", "Tanzania, United Republic of"),
                new Country("UG", "Uganda"),
                new Country("GB", "United Kingdom"),
                new Country("UA", "Ukraine"),
                new Country("US", "United States"),
                new Country("BF", "Burkina Faso"),
                new Country("UY", "Uruguay"),
                new Country("UZ", "Uzbekistan"),
                new Country("VC", "Saint Vincent and the Grenadines"),
                new Country("VE", "Venezuela"),
                new Country("VG", "British Virgin Islands"),
                new Country("VN", "Vietnam"),
                new Country("VI", "Virgin Islands (US)"),
                new Country("VA", "Holy See (Vatican City)"),
                new Country("NA", "Namibia"),
                new Country("WF", "Wallis and Futuna"),
                new Country("EH", "Western Sahara"),
                new Country("UM", "Wake Island"),
                new Country("WS", "Samoa"),
                new Country("SZ", "Swaziland"),
                new Country("CS", "Serbia and Montenegro"),
                new Country("YE", "Yemen"),
                new Country("ZM", "Zambia"),
                new Country("ZW", "Zimbabwe")
            };

            Dictionary<string, Country> dictionary = new Dictionary<string, Country>();
            foreach (var country in _countries)
            {
                dictionary[country.Iso] = country;
            }
            _countries = dictionary.Values.ToArray();
            return _countries;
        }
    }
}