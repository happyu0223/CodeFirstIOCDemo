using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.Core.Interfaces;

namespace CodeFirstIOCDemo.Dao.Frameworks
{
    public class CodeFirstIOCDemoDaoModule : IModule
    {
        public string Title
        {
            get { return "CodeFirstIOCDemoDao"; }
        }

        public string Name
        {
            get { return Assembly.GetAssembly(GetType()).GetName().Name; }
        }

        public Version Version
        {
            get { return new Version(1, 0, 0, 0); }
        }

        public void Install(IUnityContainer container)
        {
            try
            {
                container.RegisterType<CodeFirstIOCDemoContext>(new PerResolveLifetimeManager())
                    .RegisterType<IContext, CodeFirstIOCDemoContext>(new InjectionConstructor(CodeFirstIOCDemoContext.DatabaseName))
                    .RegisterType<ISettingContext, CodeFirstIOCDemoContext>(new InjectionConstructor(CodeFirstIOCDemoContext.DatabaseName))
                    .RegisterType<ISecurityContext, CodeFirstIOCDemoContext>(new InjectionConstructor(CodeFirstIOCDemoContext.DatabaseName));
            }
            catch (Exception)
            {
            }

            //container.RegisterType<IContext, VoweiContext>(new InjectionConstructor(VoweiContext.DatabaseName))
            //    .RegisterType<ISettingContext, VoweiContext>(new InjectionConstructor(VoweiContext.DatabaseName))
            //    .RegisterType<ISecurityContext, VoweiContext>(new InjectionConstructor(VoweiContext.DatabaseName));
        }
    }
}
