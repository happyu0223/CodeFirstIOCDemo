using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.Dao.Core;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    public class Setting : TableItemBase, INamedItem
    {
        /// <summary>
        /// 设置的键名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Json格式的键值
        /// </summary>
        public string JsonValue { get; set; }
    }
}
