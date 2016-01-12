using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.Core.Interfaces
{
    public interface IMvcModule : IModule
    {
        /// <summary>
        /// Entry controller name
        /// </summary>
        string EntryControllerName { get; }

        /// <summary>
        /// Enumeration of registered css files from the assembly
        /// </summary>
        IEnumerable<string> RegisteredCss { get; }

        /// <summary>
        /// Enumeration of the registered JavaScript fiels from the assembly
        /// </summary>
        IEnumerable<string> RegisteredJavaScript { get; }

        /// <summary>
        /// 获取是否有私有的数据库部署
        /// </summary>
        bool HasPrivateDatabase { get; }

        /// <summary>
        /// 安装私有的数据库部署
        /// </summary>
        /// <param name="conn">数据库连接字符串，可选</param>
        void DeployPrivateDatabase(string conn);
    }
}
