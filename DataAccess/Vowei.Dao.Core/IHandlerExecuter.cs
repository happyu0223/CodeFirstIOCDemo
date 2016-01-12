using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.Dao.Core
{
    public interface IHandlerExecuter
    {
        void Execute<TRequest>(TRequest request);

        TResponse Execute<TRequest, TResponse>(TRequest request);
    }
}
