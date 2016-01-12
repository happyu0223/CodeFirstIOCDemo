using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    /// <summary>
    /// 指明权限的类型
    /// </summary>
    public enum PermissionType : int
    {
        /// <summary>
        /// 新建
        /// </summary>
        Insert = 1,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 2,
        /// <summary>
        /// 查询
        /// </summary>
        CheckDetails = 4,

        /// <summary>
        /// 读取字段的值
        /// </summary>
        Read = CheckDetails,

        /// <summary>
        /// 修改
        /// </summary>
        Modify = 8,

        /// <summary>
        /// 修改字段的值
        /// </summary>
        Write = Modify,

        /// <summary>
        /// 字段读写权限
        /// </summary>
        ReadWrite = Read | Write,

        /// <summary>
        /// 管理
        /// </summary>
        Administrate = 16,

        /// <summary>
        /// 查看资料列表
        /// </summary>
        BrowseList = 32,

        /// <summary>
        /// 浏览其他人负责的实体权限
        /// </summary>
        BrowseOthers = 64,

        /// <summary>
        /// 编辑和删除其他人负责的实体权限
        /// </summary>
        EditOthers = 128,

        /// <summary>
        /// 增删改查
        /// </summary>
        CRUD = Insert | Delete | CheckDetails | Modify | BrowseList,

        /// <summary>
        /// 超级权限
        /// </summary>
        SuperCRUM = CRUD | BrowseOthers | EditOthers,

        /// <summary>
        /// 确认权限
        /// </summary>
        Activate = 256,
    }
}
