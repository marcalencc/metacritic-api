using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace MetacriticAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.MediaTypeMappings
                .Add(new RequestHeaderMapping("Accept", "text/html", 
                StringComparison.InvariantCultureIgnoreCase, true, "application/json"));

            config.Formatters.JsonFormatter.SerializerSettings.NullValue‌​Handling = NullValueHandling.Ignore;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "MediaItemRouteWithDetails",
                routeTemplate: "metacriticApi/{controller}/{title}/{details}",
                defaults: new { action = "GetDetails" },
                constraints: new { details = @"details|movie|album|tvshow" });

            config.Routes.MapHttpRoute(
                name: "MediaItemRouteWithYear",
                routeTemplate: "metacriticApi/{controller}/{title}/{year}",
                defaults: new { action = "GetItemWithYear" },
                constraints: new { year = @"\d+" });

            config.Routes.MapHttpRoute(
                name: "MediaItemRouteWithYearAndDetails",
                routeTemplate: "metacriticApi/{controller}/{title}/{year}/{details}",
                defaults: new { year = RouteParameter.Optional, details = RouteParameter.Optional });

        }
    }
}
