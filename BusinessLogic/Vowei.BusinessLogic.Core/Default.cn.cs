using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Collections.ObjectModel;
//using Microsoft.TeamFoundation.Client;

namespace CodeFirstIOCDemo.BusinessLogic.Core
{
    public partial class Default
    {
        public partial class Property
        {
            public class _ISupportDefaultProperties
            {
                public const string LastModified = "上次修改时间";

                public const int LastModifiedId = 1;

                public const string LastModifiedBy = "最后修改人";

                public const int LastModifiedById = 2;

                public const string OpenDate = "创建日期";

                public const int OpenDateId = 3;

                public const string Creator = "创建人";

                public const int CreatorId = 4;
            }

            public class _IDuration
            {
                public const string StartDate = "开始日期";

                public const string DueDate = "计划结束日期";
            }

            public class _ICommentable
            {
                public const string Comments = "相关评论";
            }

            public class _IOwnable
            {
                public const string Owner = "业务员";
            }
        }

        public partial class ViewConfigurations
        {
            public const string Summary = "摘要";

            public const string Details = "详情";

            public const string EditView = "编辑";

            public const string CreateShortCut = "快捷创建";

            public const string Other = "其它";

            public const string QuerySelect = "下拉框视图";

            public const string DetailsSummary = "详情摘要";

            /// <summary>
            /// 用来表示实体的标识属性
            /// </summary>
            public const string Name = "名称";

            public const string Grouping = "Grouping";
        }

        public partial class Security
        {
            /// <summary>
            /// 系统里默认的权限组
            /// </summary>
            public class Role
            {
                public const string Boss = "老板";

                public const string Owner = "所有者";

                public const string Superior = "直接上司";

                public const string Everyone = "公司其他人";

                public const string Peer = "部门其他人";

                public const string Administrators = "管理员";

                public const string BuyerDepartment = "采购部";

                public const string SalerDepartment = "销售部";
            }
        }

        public class Settings
        {
            /// <summary>
            /// 系统里所有可用的站点菜单的链接列表
            /// </summary>
            public const string AvailableMenus = "AvailableMenus";

            /// <summary>
            /// 默认站点的菜单样式 - 即老板看到的样式
            /// </summary>
            public const string DefaultSiteMap = "DefaultSiteMap";
            public const int BeginOfCustomeMenuId = 100;

            public const string SiteMap = "SiteMap";
        }
    }
}
