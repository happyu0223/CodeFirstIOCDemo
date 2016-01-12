using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    /// <summary>
    /// 项目输出物
    /// </summary>
    public class TaskOutput : INamedItem
    {
        public TaskOutput()
        {
            DependentTasks = new List<ProjectTask>();
        }

        public int Id { get; set; }

        /// <summary>
        /// 输出物名称
        /// </summary>
        public string Name { get; set; }

        public int OutputType { get; set; }

        /// <summary>
        /// 输出物的详细内容，比如链接等等
        /// </summary>
        public string Data { get; set; }

        public virtual List<ProjectTask> DependentTasks { get; set; }
    }
}
