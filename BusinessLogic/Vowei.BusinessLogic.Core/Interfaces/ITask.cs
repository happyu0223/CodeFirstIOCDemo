using Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Interfaces
{
    public interface ITask
    {
        /// <summary>
        /// 任务要求的输入物
        /// </summary>
        List<TaskOutput> TaskInput { get; set; }

        /// <summary>
        /// 任务要求的输出物
        /// </summary>
        List<TaskOutput> TaskOutput { get; set; }
    }
}
