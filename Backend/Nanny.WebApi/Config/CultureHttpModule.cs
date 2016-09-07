using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Nanny.Dal;
using Nanny.Domain.Entities.Localization;
using Nanny.Infrastructure;
using Nanny.Queries;

namespace Nanny.WebApi.Config
{
    class CultureHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            var helper = new EventHandlerTaskAsyncHelper(Request);
            context.AddOnPostAuthorizeRequestAsync(helper.BeginEventHandler,
                helper.EndEventHandler);
        }

        private async Task Request(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            if (application == null)
            {
                return;
            }

            var context = application.Context;
            var lang = context.Request.Headers["Accept-Language"];

            // eat the cookie (if any) and set the culture
            if (!string.IsNullOrEmpty(lang))
            {
                var cultureName = lang.Split(',', ';')[0];

                CultureInfo culture;
                try
                {
                    culture = new CultureInfo(cultureName);
                }
                catch (CultureNotFoundException)
                {
                    var query = new DomainCultureQuery(new DefaultCtx(),
                        (TypeCache<DomainCultureQuery, string, LangCulture[]>)
                            Startup.HttpConfiguration.DependencyResolver.GetService(
                                typeof (TypeCache<DomainCultureQuery, string, LangCulture[]>)),
                        new LangResourceSingleQuery(new DefaultCtx()));

                    var langCultures = await query.Execute(context.Request.UrlReferrer?.Authority);
                    culture = new CultureInfo(langCultures.First().Key);
                }
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
        }

        public void Dispose()
        {

        }
    }
}
