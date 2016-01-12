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
    /// 项目任务
    /// </summary>
    public class ProjectTask : INamedItem, ITask
    {
        public ProjectTask()
        {
            TaskInput = new List<TaskOutput>();
            TaskOutput = new List<TaskOutput>();
        }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }

        public int Id { get; set; }

        /// <summary>
        /// 任务工期
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// 负责的角色Id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 是否是标准任务
        /// </summary>
        public bool IsTemplateTask { get; set; }

        /// <summary>
        /// 开始时间，包括日期和时间
        /// </summary>
        public DateTime? BeginDateTime { get; set; }

        /// <summary>
        /// 结束时间，包括日期和时间
        /// </summary>
        public DateTime? DueDateTime { get; set; }

        /// <summary>
        /// 用户完成任务的时间
        /// </summary>
        public DateTime? CompleteDateTime { get; set; }

        /// <summary>
        /// 用户结束任务的时间
        /// </summary>
        public DateTime? ClosedDateTime { get; set; }

        /// <summary>
        /// 最后修改的时间
        /// </summary>
        public DateTime LastModifiedDateTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// 所属项目的Id
        /// </summary>
        public int ProjectId { get; set; }

        public virtual List<TaskOutput> TaskInput { get; set; }

        public virtual List<TaskOutput> TaskOutput { get; set; }
    }
}
