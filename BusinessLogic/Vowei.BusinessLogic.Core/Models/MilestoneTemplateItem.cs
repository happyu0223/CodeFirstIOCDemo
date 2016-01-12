using CodeFirstIOCDemo.Dao.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    public class MilestoneTemplateItem : ITableItem
    {
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 里程碑名字
        /// </summary>
        public string Name { get; set; }

        public int TemplateId { get; set; }

        public MilestoneTemplate Template { get; set; }

        /// <summary>
        /// 距离项目结束的时间
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// 距离项目结束的时间的单元，是按周，按天还是按月
        /// </summary>
        public int DistanceUnit { get; set; }
    }
}
