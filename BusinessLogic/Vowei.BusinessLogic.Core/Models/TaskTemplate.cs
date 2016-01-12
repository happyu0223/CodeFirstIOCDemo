using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    /// <summary>
    /// 任务模板，包含所有的标准任务
    /// </summary>
    public class TaskTemplate : INamedItem
    {
        public TaskTemplate()
        {
            Tasks = new List<TaskTemplateItem>();
        }

        public int Id { get; set; }

        /// <summary>
        /// 获取和设置任务名称
        /// </summary>
        public string Name { get; set; }

        public virtual List<TaskTemplateItem> Tasks { get; set; }
    }
}
