using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Interfaces
{
    public interface ICache
    {
        void Add(string key, object data);

        void Invalidate(string key);

        object Get(string key);
    }
}
