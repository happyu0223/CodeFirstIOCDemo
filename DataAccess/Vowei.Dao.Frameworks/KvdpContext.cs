using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Security;
using CodeFirstIOCDemo.BusinessLogic.Core;
using CodeFirstIOCDemo.BusinessLogic.Core.Extensions;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.BusinessLogic.Core.Models;
using CodeFirstIOCDemo.Dao.Core;
using Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models;
using System.Data.SqlClient;

namespace CodeFirstIOCDemo.Dao.Frameworks
{
    internal delegate bool FindDelegation<T>(T entity, object key);

    public class CodeFirstIOCDemoContext : IContext, ISecurityContext, ISettingContext
    {
        public const string DatabaseName = "CodeFirstIOCDemoContext";

        private CodeFirstIOCDemoContextImpl _contextImpl;
        private Hashtable _tableMap;

#if TEST
        public CodeFirstIOCDemoContextImpl Impl { get { return _contextImpl; } }
#else
        internal CodeFirstIOCDemoContextImpl Impl { get { return _contextImpl; } }
#endif

        public CodeFirstIOCDemoContext() :
            this(new CodeFirstIOCDemoContextImpl())
        {
        }

        internal CodeFirstIOCDemoContext(CodeFirstIOCDemoContextImpl impl)
        {
            _contextImpl = impl;
            _tableMap = new Hashtable();

            Comments = RegisterTable<Comment>("Comments");
            
            Roles = RegisterTable<Role>("Roles");
            Employees = RegisterTable<Employee>("Employees");
            Permissions = RegisterTable<Permission>("Permissions");
            Organizations = RegisterTable<Organization>("Organizations");
            Settings = RegisterTable<Setting>("Settings");
            MilestoneTemplates = RegisterTable<MilestoneTemplate>("MilestoneTemplates");
            MilestoneTemplateItems = RegisterTable<MilestoneTemplateItem>("MilestoneTemplateItems");
            RoleTemplates = RegisterTable<RoleTemplate>("RoleTemplates");
            TaskTemplates = RegisterTable<TaskTemplate>("TaskTemplates");
            Milestones = RegisterTable<Milestone>("Milestones");
            Projects = RegisterTable<Project>("Projects");
            TaskTemplateItems = RegisterTable<TaskTemplateItem>("TaskTemplateItems");
            ProjectTasks = RegisterTable<ProjectTask>("ProjectTasks");
            TaskOutputs = RegisterTable<TaskOutput>("TaskOutputs");
            RoleTemplateItems = RegisterTable<RoleTemplateItem>("RoleTemplateItems");
        }

        public CodeFirstIOCDemoContext(SqlConnection conn)
            : this(new CodeFirstIOCDemoContextImpl(conn))
        {
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _contextImpl.Database.ExecuteSqlCommand(sql, parameters);
        }

        // 如果封装的类型和数据库里的其他类型没有继承关系，则使用这个函数执行映射
        private IRepository<T> RegisterTable<T>(string tableName)
            where T : class, ITableItem
        {
            var result = new RepositoryImpl<T, T>(this, null, tableName);

            _tableMap.Add(typeof(T), result);

            return result;
        }

        // 如果封装的类型和数据库里的其他类型有继承关系，则使用这个函数执行映射，
        // 需要指定类型和类型的基类
        private IRepository<T> RegisterDeriveredTable<T, U>(Func<T, U> persistRouting, string tableName)
            where T : class, ITableItem
            where U : class, T
        {
            var result = new RepositoryImpl<T, U>(this, persistRouting, tableName);

            _tableMap.Add(typeof(T), result.IfImplementation);
            _tableMap.Add(typeof(U), result);

            return result.IfImplementation;
        }

        internal class RepositoryImpl<T, U> : IRepository<U>
            where T : class, ITableItem
            where U : class, T
        {
            // 被封装的数据表实现方式
            private DbSet<U> _table;
            // 保存上一次类似Where等Lambda调用保存的表达式树
            private IQueryable<U> _query;
            // 保存新数据的回调函数
            private Func<T, U> _persistRouing;
            private string _tableName;
            private CodeFirstIOCDemoContext _context;

            // 这个变量仅仅是用来在实现继承类型，避免编译器混乱用的
            public IRepository<T> IfImplementation { get; private set; }

            private RepositoryImpl(IQueryable<U> query, Func<T, U> persistRouing, string tableName)
            {
                _query = query;
                _persistRouing = persistRouing;
                _tableName = tableName;
            }

            public RepositoryImpl(CodeFirstIOCDemoContext context, Func<T, U> persistRouing, string tableName)
            {
                var property = typeof(CodeFirstIOCDemoContextImpl).GetProperty(tableName);
                // 通过反射的机制，根据“tableName”参数给出的属性名，获取实现IContext某个数据表的具体对象引用
                // 并保存到类型变量里，以便将所有的查询、Include、增删改等操作传递给这个对象。
                _table = (DbSet<U>)property.GetValue(context._contextImpl, new object[] { });
                _query = _table;
                _persistRouing = persistRouing;
                _tableName = tableName;
                _context = context;

                // 如果类型T和U不是同一个类型，说明要么U继承与T，或者U实现了T这个接口
                // 这样一来，为了规避编译器编译错误，需要再封一层
                if (typeof(T) != typeof(U))
                    IfImplementation = new RepositoryIfImpl(this, tableName);
                else // 否则就很简单了
                    IfImplementation = (IRepository<T>)this;
            }

            public RepositoryImpl(CodeFirstIOCDemoContext context)
                : this(context, null, typeof(U).Name)
            {
            }

            /// <summary>
            /// 获取该Repository对应的数据库里的表名
            /// </summary>
            public string Name { get { return _tableName; } }

            public IContextBase Context { get { return _context; } }

            public IQueryable<U> Query
            {
                get
                {
                    if (_query == null)
                        return _table;
                    else
                        return _query;
                }
            }

            public IRepository<U> Include(string navigationProperty)
            {
                if (_query == null)
                    return new RepositoryImpl<T, U>(_table.Include(navigationProperty), _persistRouing, _tableName);
                else
                    return new RepositoryImpl<T, U>(_query.Include(navigationProperty), _persistRouing, _tableName) { _table = _table };
            }

            public IQueryable<U> SqlQuery(string sql, params object[] parameters)
            {
                return _table.SqlQuery(sql, parameters).AsQueryable<U>();
            }

            public int CountQuery(string sql, params object[] parameters)
            {
                // 一个技巧：
                // http://stackoverflow.com/questions/10154349/return-count-using-raw-query-using-entity-framework-and-mvc
                return this._context._contextImpl.Database.SqlQuery<int>(sql, parameters).First();
            }

            public U FindById(int id)
            {
                return _table.Find(id);
            }

            public IEnumerable<U> Find(Expression<Func<U, bool>> predicate, int? skips, int? takes)
            {
                var result = _table.Where(predicate);
                if (skips.HasValue)
                    result = result.Skip(skips.Value);

                if (takes.HasValue)
                    result = result.Take(takes.Value);

                return result;
            }

            public virtual void Add(U item)
            {
                _table.Add(item);
            }

            public virtual void Remove(U item)
            {
                _table.Remove(item);
            }

            public U Attach(U entity)
            {
                return _table.Attach(entity);
            }
            
            public IEnumerable<U> GetAll()
            {
                return _table;
            }

            class RepositoryIfImpl : IRepository<T>
            {
                private RepositoryImpl<T, U> _outer;
                private IQueryable<U> _tmpQuery;
                private string _tableName;

                public RepositoryIfImpl(RepositoryImpl<T, U> outer, string tableName)
                {
                    _outer = outer;
                    _tableName = tableName;
                }

                public string Name { get { return _tableName; } }

                public IContextBase Context { get { return _outer._context; } }

                public IQueryable<T> Query
                {
                    get
                    {
                        if (_tmpQuery == null)
                            return _outer._table;
                        else
                            return _tmpQuery;
                    }
                }

                public IQueryable<T> SqlQuery(string sql, params object[] parameters)
                {
                    return _outer._table.SqlQuery(sql, parameters).AsQueryable<U>();
                }

                public int CountQuery(string sql, params object[] parameters)
                {
                    return this._outer._context._contextImpl.Database.SqlQuery<int>(sql, parameters).First();
                }

                public IRepository<T> Include(string navigationProperty)
                {
                    var result = new RepositoryIfImpl(_outer, _tableName);
                    result._tmpQuery = _tmpQuery == null ? _outer._table.Include(navigationProperty)
                                                         : _tmpQuery.Include(navigationProperty);
                    return result;
                }

                public virtual void Add(T item)
                {
                    if (_outer._persistRouing == null)
                        throw new InvalidOperationException("当需要从基类T的对象实例生成一个派生类型U的实例时，需要指明转换的方式！");

                    _outer._table.Add(_outer._persistRouing(item));
                }

                public T FindById(int id)
                {
                    return _outer._table.Find(id);
                }

                public virtual void Remove(T item)
                {
                    _outer._table.Remove((U)item);
                }

                public T Attach(T entity)
                {
                    return _outer.Attach((U)entity);
                }


                public IEnumerable<T> Find(Expression<Func<T, bool>> predicate, int? skips, int? takes)
                {
                    var result = _outer._table.Where(predicate);
                    if (skips.HasValue)
                        result = result.Skip(skips.Value);

                    if (takes.HasValue)
                        result = result.Take(takes.Value);

                    return result;
                }

                public IEnumerable<T> GetAll()
                {
                    return _outer._table;
                }
            }
        }

        public IRepository<Comment> Comments
        {
            get;
            private set;
        }

        public IRepository<Permission> Permissions
        {
            get;
            private set;
        }

        public IRepository<Role> Roles
        {
            get;
            private set;
        }

        public IRepository<Employee> Employees
        {
            get;
            private set;
        }

        public IRepository<Organization> Organizations
        {
            get;
            private set;
        }

        public IRepository<Setting> Settings
        {
            get;
            private set;
        }

        public IRepository<MilestoneTemplate> MilestoneTemplates { get; private set; }

        public IRepository<MilestoneTemplateItem> MilestoneTemplateItems { get; private set; }

        public IRepository<TaskTemplate> TaskTemplates { get; private set; }

        public IRepository<Milestone> Milestones { get; private set; }

        public IRepository<Project> Projects { get; private set; }

        public IRepository<TaskTemplateItem> TaskTemplateItems { get; private set; }

        public IRepository<ProjectTask> ProjectTasks { get; private set; }

        public IRepository<TaskOutput> TaskOutputs { get; private set; }

        public IRepository<RoleTemplate> RoleTemplates { get; private set; }

        public IRepository<RoleTemplateItem> RoleTemplateItems { get; private set; }

        public System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            // TODO: HACK，因为修改了元数据数据库会将缓存实效，在这里做一个Hack，每次SaveChanges之前先看看是否有必要重建缓存
            //var cache = IocHelper.Container.Resolve<ICache>();
            //if (cache.Get(Default.Cache.Keys.MetaProperties) == null)
            //{
            //    RefreshMetaSetCache();
            //}

            return _contextImpl.SaveChanges();
        }

        int IContextBase.SaveChanges()
        {
            return this.SaveChanges();
        }

        //private void RefreshMetaSetCache()
        //{
        //    // 生成缓存
        //    foreach (var et in new Type[] {
        //        typeof(Customer), typeof(Contact), typeof(Opportunity), typeof(Activity), typeof(Product)
        //    })
        //    {
        //        MetaSet.Load(et);
        //    }
        //}

        public void Dispose()
        {
            if (_contextImpl != null)
            {
                _contextImpl.Dispose();
                _contextImpl = null;
            }
        }

        public IQueryable<T> ExecuteSavedQuery<T>(string sql, params object[] parameters)
        {
            return _contextImpl.Database.SqlQuery(typeof(T), sql, parameters).OfType<T>().AsQueryable<T>();
        }
    }
}
