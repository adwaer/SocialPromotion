using System.Web.Http;

namespace Nanny.WebApi.Config
{
    public class FiltersConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}
