using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.BusinessLogic.Core.Models;
using CodeFirstIOCDemo.Dao.Core;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Interfaces
{
    public partial interface ISettingContext : IContextBase
    {
        /// <summary>
        /// 系统的设置
        /// </summary>
        IRepository<Setting> Settings { get; }
    }
}
