using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        public string Href { get; set; }
    }

    public class SiteMenuItem
    {
        public string Name { get; set; }

        public int MenuId { get; set; }

        public int? ParentId { get; set; }
    }
}
