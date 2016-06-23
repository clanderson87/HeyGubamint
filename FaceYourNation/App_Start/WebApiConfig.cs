using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace FaceYourNation
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //Everything below is EXPREIMENTAL AND IT COULD KILL ME!!!
            //For GetBillPublicPosition
            config.Routes.MapHttpRoute(
                name: "GetPositionResult",
                routeTemplate: "api/{controller}/{_dis}/{_house}/{_senate}",
                defaults: new { _senate = RouteParameter.Optional, _house = RouteParameter.Optional }
            );
            
            //For AddBill
            config.Routes.MapHttpRoute(
                name: "PostBill",
                routeTemplate: "api/{controller}"
            );

            //For AddBillPosition
            config.Routes.MapHttpRoute(
                name: "PostPositionForBill",
                routeTemplate: "api/{controller}/{action}"
            );
        }
    }
}
