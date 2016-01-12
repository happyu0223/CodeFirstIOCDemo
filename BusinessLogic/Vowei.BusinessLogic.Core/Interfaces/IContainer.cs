using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Interfaces
{
    public interface IContainer<T>
    {
        IQueryable<T> Children { get; }

        void Add(T child);

        void Remove(T child);

        /// <summary>
        /// 清除所有的子对象
        /// </summary>
        void ClearChildren();

        T RemoveById(object id);
    }
}
