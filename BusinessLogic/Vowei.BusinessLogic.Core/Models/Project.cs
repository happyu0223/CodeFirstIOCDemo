using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.Dao.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models
{
    public class Project : INamedItem
    {
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

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public int Status { get; set; }

        public string Pem { get; set; }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
