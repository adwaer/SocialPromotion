using System;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Adwaer.Identity;
using Nanny.Dal;
using Nanny.Domain.Entities;
using Nanny.Queries;
using Nanny.WebApi.Identity;

namespace Nanny.WebApi.Config
{
    public class BasicAuthHttpModule : IHttpModule
    {
        private const string Realm = "AngularWebAPI";

        public void Init(HttpApplication context)
        {
            var helper = new EventHandlerTaskAsyncHelper(Request);
            context.AddOnPostAuthorizeRequestAsync(helper.BeginEventHandler,
                helper.EndEventHandler);
        }

        private async Task Request(object sender, EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    await AuthenticateUser(authHeaderVal.Parameter);
                }
            }

            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate", $"Basic realm=\"{Realm}\"");
            }
        }

        public static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
        
        private async Task<bool> AuthenticateUser(string credentials)
        {
            var encoding = Encoding.GetEncoding("iso-8859-1");
            credentials = encoding.GetString(Convert.FromBase64String(credentials));

            var credentialsArray = credentials.Split(':');
            var username = credentialsArray[0];
            var password = credentialsArray[1];

            var userManager = IdentityUserManager<SimpleCustomerAccount>.Get<SimpleCustomerAccount, UserRole>(new DefaultCtx(), new OnCreateUserAction(new CultureQuery(new DefaultCtx())));

            SimpleCustomerAccount account = await userManager.FindAsync(username, password);
            if (account == null)
            {
                return false;
            }

            var identity = new GenericIdentity(username);
            SetPrincipal(new GenericPrincipal(identity, null));
            return true;
        }
        
        public void Dispose()
        {
        }
    }
}