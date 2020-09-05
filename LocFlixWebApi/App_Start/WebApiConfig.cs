using LocFlixWebApi.Services;
using LocFlixWebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace LocFlixWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            var container = new UnityContainer();
            container.RegisterType<IFileExplorerService, FileExplorerService>();
            config.DependencyResolver = new UnityDependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
