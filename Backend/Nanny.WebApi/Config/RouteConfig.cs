﻿using System.Web.Http;
using Nanny.WebApi.Attributes;

namespace Nanny.WebApi.Config
{
    public class RouteConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Filters.Add(new ValidateModelAttribute());
        }
    }
}
