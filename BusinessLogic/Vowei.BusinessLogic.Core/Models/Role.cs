using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.Dao.Core;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    public class Role : Identity, IContainer<Identity>
    {
        public Role()
        {
            Children = new List<Identity>();
        }

        public Role(string name)
            : base(name)
        {
            Children = new List<Identity>();
        }

        public int? LeadEmployeeId { get; set; }

        public int Level { get; set; }

        public bool Managable { get; set; }

        public List<Identity> Children
        {
            get;
            private set;
        }

        IQueryable<Identity> IContainer<Identity>.Children
        {
            get { return Children.AsQueryable<Identity>(); }
        }

        public void Add(Identity child)
        {
            // 下面这一行代码要求输入的参数child只能是从vowei.data出去的数据库对象
            if (child is Role)
            {
                ((Role)child).Level = Level + 1;
            }

            Children.Add((Identity)child);
        }

        public void Remove(Identity child)
        {
            RemoveById(child.Id);
        }

        public Identity RemoveById(object id)
        {
            Guid key = (Guid)id;
            var ret = Children.SingleOrDefault(i => i.Id.Equals(key));
            if (ret == null)
                throw new InvalidOperationException(string.Format("Id为{0}的权限控制实体不存在！", key));

            Children.Remove(ret);

            return ret;
        }

        public void ClearChildren()
        {
            Children.Clear();
        }

    }
}
