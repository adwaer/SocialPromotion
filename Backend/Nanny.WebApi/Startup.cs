using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Nanny.Business;
using Nanny.WebApi.Config;
using Owin;

namespace Nanny.WebApi
{
    public class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; private set; }
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder app)
        {
            var container = IocConfig.Configure();
            ConfigureApp(container, app);

            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Service is online.");
                //test comment
            });
        }

        protected void ConfigureApp(IContainer container, IAppBuilder app)
        {
            HttpConfiguration = new HttpConfiguration
            {
                DependencyResolver = new AutofacWebApiDependencyResolver(container)
            };

            HttpConfiguration.Formatters.Clear();
            HttpConfiguration.Formatters.Add(new JsonMediaTypeFormatter());
            HttpConfiguration.Formatters.JsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
            //HttpConfiguration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(HttpConfiguration);

            //ConfigureOAuth(app);
            RouteConfig.Register(HttpConfiguration);
            FiltersConfig.Register(HttpConfiguration);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(HttpConfiguration);
            app.Use<GlobalExceptionMiddleware>();
        }

        //    public void ConfigureOAuth(IAppBuilder app)
        //    {
        //        app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
        //        OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

        //        OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions()
        //        {
        //            AllowInsecureHttp = true,
        //            TokenEndpointPath = new PathString("/Token"),
        //            AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        //            Provider = new SimpleAuthorizationServerProvider(IdentityUserManager.Get(new DefaultCtx()))
        //        };

        //        // Token Generation
        //        app.UseOAuthAuthorizationServer(oAuthServerOptions);
        //        app.UseOAuthBearerAuthentication(OAuthBearerOptions);

        //        ////Configure Google External Login
        //        //googleAuthOptions = new GoogleOAuth2AuthenticationOptions()
        //        //{
        //        //    ClientId = "xxxxxx",
        //        //    ClientSecret = "xxxxxx",
        //        //    Provider = new GoogleAuthProvider()
        //        //};
        //        //app.UseGoogleAuthentication(googleAuthOptions);

        //        ////Configure Facebook External Login
        //        //facebookAuthOptions = new FacebookAuthenticationOptions()
        //        //{
        //        //    AppId = "xxxxxx",
        //        //    AppSecret = "xxxxxx",
        //        //    Provider = new FacebookAuthProvider()
        //        //};
        //        //app.UseFacebookAuthentication(facebookAuthOptions);
        //    }
    }
}
