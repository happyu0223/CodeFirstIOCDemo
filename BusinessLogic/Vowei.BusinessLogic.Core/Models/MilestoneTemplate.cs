using CodeFirstIOCDemo.Dao.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    public class MilestoneTemplate : ITableItem
    {
        public MilestoneTemplate() { Milestones = new List<MilestoneTemplateItem>(); }

        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// 里程碑名字
        /// </summary>
        public string Name { get; set; }

        public virtual List<MilestoneTemplateItem> Milestones { get; set; }
    }
}
