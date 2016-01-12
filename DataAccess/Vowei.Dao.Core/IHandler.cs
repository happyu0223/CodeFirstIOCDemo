using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.Dao.Core
{
    public interface IHandler<in TRequest, out TResponse>
    {
        TResponse Execute(TRequest request);
    }

    public interface IHandler<in TRequest>
    {
        void Execute(TRequest request);
    }

    public interface IHandler
    {
    }
}
