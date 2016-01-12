using System.Web.Http;
using Com.Gm.CodeFirstIOCDemo.Api;
using WebActivatorEx;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Com.Gm.CodeFirstIOCDemo.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            Swashbuckle.Bootstrapper.Init(GlobalConfiguration.Configuration);

            SwaggerSpecConfig.Customize(c =>
                {
                    c.IncludeXmlComments(GetXmlCommentsPath());
                });
            //var thisAssembly = typeof(SwaggerConfig).Assembly;

            //GlobalConfiguration.Configuration
            //    .EnableSwagger(c =>
            //    {
            //        c.IncludeXmlComments(GetXmlCommentsPath());
            //        c.SingleApiVersion("v1", "GMfacet");
            //    }
            //).EnableSwaggerUi(c => { });
        }

        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\CodeFirstIOCDemo.Api.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}