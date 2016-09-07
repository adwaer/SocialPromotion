using Microsoft.Owin;

[assembly: OwinStartup(typeof(Nanny.Web.Startup))]

namespace Nanny.Web
{
    public class Startup : WebApi.Startup
    {
    }
}
