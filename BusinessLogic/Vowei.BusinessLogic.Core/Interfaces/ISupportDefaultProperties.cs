using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Interfaces
{
    public interface ISupportDefaultProperties
    {
        DateTime OpenDate { get; set; }

        DateTime LastModified { get; set; }

        string Creator { get; set; }

        string LastModifiedBy { get; set; }
    }
}
