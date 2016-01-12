using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    public class Employee : Identity
    {
        public Employee()
        {
            Subordinates = new List<Employee>();
        }

        public Employee(string name)
            : base(name)
        {
            Subordinates = new List<Employee>();
        }

        /// <summary>
        /// 获取和设置这个雇员的汇报对象
        /// </summary>
        public int? ReportToId { get; set; }

        public string Mobile { get; set; }

        /// <summary>
        /// 获取雇员的昵称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 获取和设置雇员的邮件地址
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 获取和设置员工的类型，是普通员工还是供应商
        /// </summary>
        public string Category { get; set; }

        public bool IsEnabled { get; set; }

        public List<Employee> Subordinates { get; private set; }
    }
}
