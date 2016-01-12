using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.Dao.Core;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    /// <summary>
    /// 采取Role Based Access Control方式控制的权限
    /// </summary>
    public class Permission : TableItemBase, INamedItem
    {
        /// <summary>
        /// 获取和设置权限所管理的实体或者元数据字段属性
        /// </summary>
        public int EntityOrMetaId { get; set; }

        /// <summary>
        /// 获取和设置具体的权限情况
        /// </summary>
        public int Setting { get; set; }

        public string Name
        {
            get;
            set;
        }
    }
}
