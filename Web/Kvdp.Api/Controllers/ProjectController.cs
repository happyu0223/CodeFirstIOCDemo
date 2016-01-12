using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;

namespace Com.Gm.CodeFirstIOCDemo.Api
{
    public class ProjectController : ApiController
    {
        private IContext _context;

        public ProjectController(IContext context)
        {
            _context = context;
        }

        public Milestone[] GetMilestones(int mid)
        {
            throw new NotImplementedException();
        }
    }
}
