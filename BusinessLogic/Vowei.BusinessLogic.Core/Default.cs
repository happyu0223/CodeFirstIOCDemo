using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.BusinessLogic.Core
{
    public partial class Default
    {
        public partial class Property
        {
            public class _Entity
            {
                public const string OpenDate = Default.Property._ISupportDefaultProperties.OpenDate;

                public const int OpenDateId = Default.Property._ISupportDefaultProperties.OpenDateId;

                public const string LastModified = Default.Property._ISupportDefaultProperties.LastModified;

                public const int LastModifiedId = Default.Property._ISupportDefaultProperties.LastModifiedId;

                public const string LastModifiedBy = Default.Property._ISupportDefaultProperties.LastModifiedBy;

                public const int LastModifiedById = Default.Property._ISupportDefaultProperties.LastModifiedById;

                public const string Creator = Default.Property._ISupportDefaultProperties.Creator;

                public const int CreatorId = Default.Property._ISupportDefaultProperties.CreatorId;
            }

            public const string _RomanizationExt = "_ROMANIZATION";
        }

        public class Paging
        {
            /// <summary>
            /// 分页中默认每页显示的记录条数
            /// </summary>
            public const int PagingCount = 20;

            /// <summary>
            /// 显示最新的数据
            /// </summary>
            public const int Top3 = 3;
        }

        public class _MetaProperty
        {
            public class Formula
            {
                public class Keyword
                {
                    public const string Global = "__Global";
                }
            }

            public class Type
            {
                public const string Number = "number";

                public const string String = "string";

                public const string Address = "address";

                public const string MultiValues = "multivalue";

                public const string DateTime = "datetime";

                public const string Date = "date";

                public const string Time = "time";

                public const string User = "user";

                public const string Html = "html";

                public const string Query = "reference";

                public const string AutoId = "autoid";

                public const string Choice = "choice";

                public const string Checkbox = "checkbox";

                public const string Radio = "radio";

                public const string File = "file";

                public const string Table = "table";

                public const string Formula = "formula";

                public const string Boolean = "boolean";

                public const string CascadingChoices = "cascading";

                public const string Price = "price";

                public const string Combined = "combined";
            }

            public const string EntityId = "EntityId";

            public const int CascadingChoiceTopLevel = 0;

            public const string RemoteServiceEntity = "RemoteServiceEntity";

            public const string GetAddressCascadingChoice = "GetAddressCascadingChoice";
        }

        public partial class ViewConfigurations
        {
            public class ViewType
            {
                public const string ViewGroup = "ViewGroup";

                public const string View = "View";
            }
        }

        public class Cache
        {
            public class Keys
            {
                /// <summary>
                /// 所有的元数据缓存
                /// </summary>
                public const string MetaProperties = "MetaProperties";

                /// <summary>
                /// 所有的实体的各个视图设置缓存
                /// </summary>
                public const string ViewConfigurations = "ViewConfigurations";

                /// <summary>
                /// 系统中所有用户的权限缓存
                /// </summary>
                public const string IdentityPermissions = "IdentityPermissions";

                public const string Roles = "Roles";

                public const string Employees = "Employees";

                public const string EntityTypes = "EntityTypes";

                public const string AllMenus = "AllMenus";
            }
        }

        public partial class Security
        {
            /// <summary>
            /// 保存代表实体的权限Id
            /// </summary>
            public class Permission
            {
                public static readonly int Settings = 6000006;

                /// <summary>
                /// 管理BOSS权限组
                /// </summary>
                public static readonly int ManageBoss = 6000011;
                public static readonly int Statistics = 6000012;
            }

            // TODO: 在支持多组织之后，删掉这个常量
            public static readonly int OrganizationId = 0;
        }
    }
}
