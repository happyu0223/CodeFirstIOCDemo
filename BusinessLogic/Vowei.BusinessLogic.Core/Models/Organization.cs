using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.Dao.Core;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    public class Organization : TableItemBase, INamedItem
    {
        public Organization()
        {
            Roles = new List<Role>();
            Employees = new List<Employee>();
        }

        public Organization(string name)
            : this()
        {
            Name = name;
        }

        /// <summary>
        /// 上级公司Id
        /// </summary>
        int? SuperiorId { get; set; }

        public string Name
        {
            get;
            set;
        }

        public List<Role> Roles
        {
            get;
            private set;
        }

        public List<Employee> Employees
        {
            get;
            private set;
        }
        
        public Permission CreatePermission(int secret, int permission)
        {
            var ret = new Permission()
            {
                EntityOrMetaId = secret,
                Setting = permission,
                OrganizationId = Id
            };

            return ret;
        }

        public IQueryable<Role> QueryRoles(ISecurityContext context)
        {
            var queryBuilder = context.Roles.Include("Lead").Include("Children").Include("Roles").Query;
            var roles = queryBuilder.Where(r => r.OrganizationId.Equals(Id) && r.Managable);
            return roles.OrderBy(r => r.Level);
        }

        public IQueryable<Role> QueryRolesPermission(ISecurityContext context)
        {
            var queryBuilder = context.Roles.Include("Roles").Include("Children").Include("Permissions").Query;
            var roles = queryBuilder.Where(r => r.OrganizationId.Equals(Id));
            return roles.OrderBy(r => r.Level);
        }

        public IQueryable<Employee> QueryEmployees(ISecurityContext context)
        {
            var impl = context;
            return impl.Employees.Include("Roles")
                                 .Include("ReportTo")
                                 .Include("Permissions")
                                 .Query
                                 .Where(e => e.OrganizationId.Equals(Id) && e.IsEnabled);
        }

        public void DisableEmployment(string email, ISecurityContext context)
        {
            var employee = context.Employees.Include("Roles").Query.Single(e => e.Name == email);
            employee.IsEnabled = false;

            // 将员工从各个权限组中删除
            foreach (var role in employee.Roles)
            {
                role.Remove(employee);
            }
        }

        public void EnableEmployment(string email, ISecurityContext context)
        {
            var employee = context.Employees.Query.Single(e => e.Name == email);
            employee.IsEnabled = true;
        }

        public Employee CreateEmployee(string username, ISecurityContext context)
        {
            var employee = context.Employees.Query.SingleOrDefault(e => e.Name == username && e.OrganizationId == Id);

            if (employee == null)
            {
                return new Employee(username) { OrganizationId = Id, IsEnabled = true };
            }
            else
            {
                throw new InvalidOperationException(string.Format("\"{0}\"已经或曾经是公司\"{1}\"的雇员，请通过启用雇员界面添加新员工！", username, Name));
            }
        }
        
        public Role CreateRole(string role)
        {
            var ret = new Role(role) { OrganizationId = Id, Level = 0, Managable = true };

            return ret;
        }
    }
}
