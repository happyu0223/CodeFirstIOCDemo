using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    /// <summary>
    /// 对象的状态，表示是否被删除！
    /// </summary>
    public enum ItemStatus
    {
        // 有效的
        Active = 0,
        // 无效的
        Invalid = 1,
        // 已经关闭了
        Closed = 2,
        // 已经放到回收站了
        Trashed = 3,
        // 已经永久删除了
        Deleted = 4,
        // 等待确认
        Pending = 5,
        //完成了
        Completed = 6
    }
}
