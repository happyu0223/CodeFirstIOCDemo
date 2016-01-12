using Com.Gm.CodeFirstIOCDemo.Core;
using GMK.OperationSystem.WFProxy.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Com.Gm.CodeFirstIOCDemo.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            //Enables the support for CORS.
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Filters.Add(new CustomAuthentication());
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            json.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            var allowedSites = ConfigurationManager.AppSettings["AllowedSites"];
            if (!string.IsNullOrWhiteSpace(allowedSites)) config.EnableCors(new EnableCorsAttribute(allowedSites, "*", "*"));
            config.DependencyResolver = new UnityResolver(IocHelper.Container);
        }
    }
}
