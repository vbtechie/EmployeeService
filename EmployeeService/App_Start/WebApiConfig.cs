using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net.Http.Headers;

namespace EmployeeService
{
    public static class WebApiConfig
    {
        // Another approach for formatting JSON from browser
        //public class CustomJsonFormatter : JsonMediaTypeFormatter
        //{
        //    public CustomJsonFormatter()
        //    {
        //        this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
        //    }

        //    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        //    {
        //        base.SetDefaultContentHeaders(type, headers, mediaType);

        //        headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    }
        //}

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Understanding MediaTypeFormatter

            // 1. How to return only JSON formatted data from API 
            // config.Formatters.Remove(config.Formatters.XmlFormatter);

            // 2. How to return only XML formatted data from API
            // config.Formatters.Remove(config.Formatters.JsonFormatter);

            // 3a. When request is made from  Web Browser
            // config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            // 3b. Register our custom Formatter <=> When request is made from  Web Browser
            // config.Formatters.Add(new CustomJsonFormatter());

            // Indent JSON data
            // config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            // Camel case instead of Pascal case
           // config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
        }
    }
}
