using Com.Gm.CodeFirstIOCDemo.Core;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.Dao.Frameworks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using MultipartDataMediaFormatter;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using Unity.WebApi;

namespace Com.Gm.CodeFirstIOCDemo.Api
{
    /// <summary>
    /// 定义 ASP.NET 应用程序中的所有应用程序对象共有的方法、属性和事件。
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("Application_Start");

        public void StartApplication()
        {
            //ASP.NET WebApi: MultipartDataMediaFormatter see: http://www.codeproject.com/Tips/652633/ASP-NET-WebApi-MultipartDataMediaFormatter
            GlobalConfiguration.Configuration.Formatters.Add(new FormMultipartEncodedMediaTypeFormatter());
        }

        protected void Application_Start()
        {
            var container = BuildUnityContainer();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            // DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            IocHelper.Container = container;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //ASP.NET WebApi: MultipartDataMediaFormatter see: http://www.codeproject.com/Tips/652633/ASP-NET-WebApi-MultipartDataMediaFormatter
            GlobalConfiguration.Configuration.Formatters.Add(new FormMultipartEncodedMediaTypeFormatter());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            return container;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<CodeFirstIOCDemoContext>(new PerResolveLifetimeManager())
                .RegisterType<IContext, CodeFirstIOCDemoContext>(new InjectionConstructor())
                .RegisterType<ISettingContext, CodeFirstIOCDemoContext>(new InjectionConstructor())
                .RegisterType<ISecurityContext, CodeFirstIOCDemoContext>(new InjectionConstructor());
        }
    }
}
