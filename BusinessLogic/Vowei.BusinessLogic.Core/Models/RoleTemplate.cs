using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    public class RoleTemplate : INamedItem
    {
        public RoleTemplate()
        {
            Items = new List<RoleTemplateItem>();
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public virtual List<RoleTemplateItem> Items { get; set; }
    }
}
