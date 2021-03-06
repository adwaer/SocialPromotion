﻿using Nanny.Cqrs.Query;
using Nanny.Domain.Entities.Dictionaries;

namespace Nanny.DicApi.Controllers
{
    public class LanguageController : AbstractApi<Language>
    {
        public LanguageController(SimpleQuery simpleQuery) : base(simpleQuery)
        {
        }
    }
}
