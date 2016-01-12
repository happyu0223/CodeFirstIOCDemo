using Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    /// <summary>
    /// 标准任务
    /// </summary>
    public class TaskTemplateItem : INamedItem, ITask
    {
        public TaskTemplateItem()
        {
            TaskInput = new List<TaskOutput>();
            TaskOutput = new List<TaskOutput>();
        }

        public int Id { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 统一任务编号
        /// </summary>
        public string TaskNumber { get; set; }

        /// <summary>
        /// 所属任务模板的Id
        /// </summary>
        public int TaskTemplateId { get; set; }

        /// <summary>
        /// 任务工期
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// 负责的角色Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 任务要求的输入物
        /// </summary>
        public virtual List<TaskOutput> TaskInput { get; set; }

        /// <summary>
        /// 任务要求的输出物
        /// </summary>
        public virtual List<TaskOutput> TaskOutput { get; set; }
    }
}
