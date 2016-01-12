using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.Dao.Core
{
    /// <summary>
    /// 代表数据库中的一个表
    /// </summary>
    /// <typeparam name="T">OR映射里的类型</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 获取数据表的名称(在数据库中对应的表) 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 返回一个组合后的IQueryable查询
        /// </summary>
        IQueryable<T> Query { get; }

        /// <summary>
        /// 添加外键查询
        /// </summary>
        /// <param name="navigationProperty">OR映射中对象的外键属性</param>
        /// <returns>返回对象本身,以达到IRepository.Include("Property1").Include("Property2").Query的效果</returns>
        IRepository<T> Include(string navigationProperty);

        /// <summary>
        /// 往数据层中添加一个新的对象
        /// </summary>
        /// <param name="item">新对象</param>
        void Add(T item);

        /// <summary>
        /// 在数据层中删除一个对象
        /// </summary>
        /// <param name="item">要删除的对象</param>
        void Remove(T item);

        T FindById(int id);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate, int? skips, int? takes);

        IEnumerable<T> GetAll();

        // T SaveOrUpdate(T entity);

        /// <summary>
        /// 用于更新操作时，将尚未和数据库关联的对象关联
        /// </summary>
        /// <param name="entity">尚未和数据库关联的对象</param>
        /// <returns>一个已经和数据库关联的对象</returns>
        T Attach(T entity);

        IQueryable<T> SqlQuery(string sql, params object[] parameters);

        int CountQuery(string sql, params object[] parameters);

        /// <summary>
        /// 获取所属的数据库
        /// </summary>
        IContextBase Context { get; }
    }
}
