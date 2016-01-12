using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using CodeFirstIOCDemo.Core.Interfaces;

namespace CodeFirstIOCDemo.Web
{
    public class PluginManager
    {
        public PluginManager()
        {
            Modules = new Dictionary<IModule, Assembly>();
            MvcModules = new Dictionary<IMvcModule, Assembly>();
        }

        private static PluginManager _current;
        public static PluginManager Current
        {
            get { return _current ?? (_current = new PluginManager()); }
        }

        internal Dictionary<IModule, Assembly> Modules { get; set; }

        internal Dictionary<IMvcModule, Assembly> MvcModules { get; set; }

        public IEnumerable<IModule> GetModules()
        {
            return Modules.Select(m => m.Key).ToList();
        }

        public IEnumerable<IMvcModule> GetMvcModules()
        {
            return MvcModules.Select(m => m.Key).ToList();
        }

        public IModule GetModule(string name)
        {
            return GetModules().FirstOrDefault(m => m.Name == name);
        }
    }
}