using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.Dao.Core;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Interfaces
{
    public interface INamedItem : ITableItem
    {
        String Name { get; set; }
    }
}
