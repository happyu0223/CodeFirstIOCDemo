using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.Dao.Core
{
    public class TableItemBase : ITableItem
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public bool IsTransient()
        {
            return Id == 0;
        }

        public bool Equals(ITableItem other)
        {
            return Id == other.Id;
        }
    }
}
