using Com.Gm.CodeFirstIOCDemo.Core;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.Dao.Frameworks;
using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Owin;
using System;
using System.Web.Http;
using System.Web.Mvc;
using Unity.WebApi;

[assembly: OwinStartup(typeof(Com.Gm.CodeFirstIOCDemo.Api.Bootstrap))]
namespace Com.Gm.CodeFirstIOCDemo.Api
{
    /// <summary>
    /// OWIN startup class.
    /// </summary>
    public class Bootstrap
    {
        /// <summary>
        /// OWIN start up method
        /// </summary>
        /// <param name="app">The app.</param>
        public void Configuration(IAppBuilder app)
        {
            var config = new System.Web.Http.HttpConfiguration();
            app.Use((context, next) =>
            {
                return next.Invoke();
            });
            app.UseStageMarker(PipelineStage.Authenticate);
            Swashbuckle.Bootstrapper.Init(config);
            WebApiConfig.Register(config);
            app.UseWebApi(config);
            app.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}