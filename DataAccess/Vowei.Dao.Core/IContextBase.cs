using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.Dao.Core
{
    public interface IContextBase : IDisposable
    {
        int ExecuteSqlCommand(string sql, params object[] parameters);

        IQueryable<T> ExecuteSavedQuery<T>(string sql, params object[] parameters);

        int SaveChanges();

        Task<int> SaveChangesAsync();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
