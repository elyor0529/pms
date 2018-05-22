using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Cors;
using PMS.Api.Providers;
using PMS.Api.Filters;
using Newtonsoft.Json;

namespace PMS.Api
{
    public static class ApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // formatter  
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =  ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            config.Formatters.JsonFormatter.SerializerSettings.DateParseHandling = DateParseHandling.DateTime;
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            config.Formatters.JsonFormatter.SerializerSettings.DateFormatString = "MM/dd/yyyy";

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("ActionApi", "api/{controller}/{action}/{id}", new { id = RouteParameter.Optional });
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            //enable CORS  
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}
