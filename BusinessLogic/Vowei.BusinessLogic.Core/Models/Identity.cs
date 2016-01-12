using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.Dao.Core;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    public class Identity : TableItemBase, INamedItem
    {
        public Identity()
        {
            Roles = new List<Role>();
            Permissions = new List<Permission>();
        }

        public Identity(string name)
            : this()
        {
            Name = name;
        }
        
        /// <summary>
        /// 用户的权限设置
        /// </summary>
        public List<Permission> Permissions
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取该雇员所属的权限组列表
        /// </summary>
        public List<Role> Roles { get; private set; }

        public string Name
        {
            get;
            set;
        }

        public void Grant(Permission child)
        {
            Permissions.Add((Permission)child);
        }

        public void Revoke(Permission child)
        {
            RevokePermissionById(child.Id);
        }

        public Permission RevokePermissionById(object id)
        {
            var key = (int)id;
            var ret = Permissions.SingleOrDefault(i => i.Id.Equals(key));
            if (ret == null)
                throw new InvalidOperationException(string.Format("Id为{0}的权限控制实体不存在！", key));

            Permissions.Remove(ret);

            return ret;
        }

        public void ClearRoles()
        {
            Roles.Clear();
        }
    }
}
