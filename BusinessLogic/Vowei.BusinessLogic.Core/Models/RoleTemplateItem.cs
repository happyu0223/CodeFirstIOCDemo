using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    public class RoleTemplateItem : INamedItem
    {
        public RoleTemplateItem()
        {
            Children = new List<RoleTemplateItem>();
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public int Level { get; set; }

        public RoleTemplateItem Parent { get; set; }

        public virtual List<RoleTemplateItem> Children { get; set; }
    }
}
