using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Com.Gm.CodeFirstIOCDemo.Api
{    
    // 参考文档：http://www.asp.net/web-api/overview/advanced/dependency-injection
    public class UnityResolver : IDependencyResolver, IServiceLocator
    {
        protected IUnityContainer container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            container.Dispose();
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return container.ResolveAll<TService>();
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return container.ResolveAll(serviceType);
        }

        public TService GetInstance<TService>(string key)
        {
            return container.Resolve<TService>(key);
        }

        public TService GetInstance<TService>()
        {
            return container.Resolve<TService>();
        }

        public object GetInstance(Type serviceType, string key)
        {
            return container.Resolve(serviceType, key);
        }

        public object GetInstance(Type serviceType)
        {
            return container.Resolve(serviceType);
        }
    }
}