using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.BusinessLogic.Core.Models;
using CodeFirstIOCDemo.Dao.Core;
using Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models;

namespace CodeFirstIOCDemo.BusinessLogic.Core.Interfaces
{
    public partial interface IContext : IContextBase
    {
        IRepository<Comment> Comments { get; }

        IRepository<MilestoneTemplate> MilestoneTemplates { get; }

        IRepository<MilestoneTemplateItem> MilestoneTemplateItems { get; }

        IRepository<TaskTemplate> TaskTemplates { get; }

        IRepository<Milestone> Milestones { get; }

        IRepository<Project> Projects { get; }

        IRepository<TaskTemplateItem> TaskTemplateItems { get; }

        IRepository<ProjectTask> ProjectTasks { get; }

        IRepository<TaskOutput> TaskOutputs { get; }

        IRepository<RoleTemplate> RoleTemplates { get; }

        IRepository<RoleTemplateItem> RoleTemplateItems { get; }
    }
}
