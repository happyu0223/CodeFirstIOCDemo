using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.BusinessLogic.Core.Models;
using CodeFirstIOCDemo.Dao.Core;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Interfaces
{
    /// <summary>
    /// 跟用户安全设置以及权限组设置相关的数据库
    /// </summary>
    public interface ISecurityContext : IContextBase
    {
        /// <summary>
        /// 获取权限组列表
        /// </summary>
        IRepository<Role> Roles { get; }

        /// <summary>
        /// 获取雇员列表
        /// </summary>
        IRepository<Employee> Employees { get; }

        /// <summary>
        /// 获取权限列表
        /// </summary>
        IRepository<Permission> Permissions { get; }

        /// <summary>
        /// 获取公司里的子公司列表
        /// </summary>
        IRepository<Organization> Organizations { get; }
    }
}
