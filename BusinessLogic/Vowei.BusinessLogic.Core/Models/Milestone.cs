using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    public class Milestone : INamedItem
    {
        /// <summary>
        /// 里程碑的名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 里程碑模板的Id
        /// </summary>
        public int MilestoneTemplateId { get; set; }

        public DateTime BeginDate { get; set; }

        /// <summary>
        /// 距离项目结束的时间
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// 距离项目结束的时间的单元，是按周，按天还是按月
        /// </summary>
        public int DistanceUnit { get; set; }

        /// <summary>
        /// 所属项目的Id
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// 根据里程碑模板和项目时间反推的里程碑结束时间
        /// </summary>
        public DateTime DueDate { get; set; }
    }
}
