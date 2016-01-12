using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    /// <summary>
    /// 距离项目结束的时间的单元，是按周，按天还是按月
    /// </summary>
    public enum DistanceUnit
    {
        /// <summary>
        /// 按周
        /// </summary>
        ByWeeks,
        /// <summary>
        /// 按天
        /// </summary>
        ByDays,
        /// <summary>
        /// 按月
        /// </summary>
        ByMonths
    }
}
