using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MetacriticAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "MediaItemRoute",
                routeTemplate: "api/{controller}/{title}");

            config.Routes.MapHttpRoute(
                name: "MediaItemRouteWithYear",
                routeTemplate: "api/{controller}/{title}/{year}",
                defaults: new { action = "GetItemWithYear" },
                constraints: new { year = @"\d+" });

            config.Routes.MapHttpRoute(
                name: "MediaItemRouteWithDetails",
                routeTemplate: "api/{controller}/{title}/{details}",
                defaults: new { action = "GetDetails" });

            config.Routes.MapHttpRoute(
                name: "MediaItemRouteWithYearAndDetails",
                routeTemplate: "api/{controller}/{title}/{year}/{details}");
        }
    }
}
