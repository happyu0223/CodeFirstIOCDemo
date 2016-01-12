using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstIOCDemo.BusinessLogic.Core.Models;
using Com.Gm.CodeFirstIOCDemo.BusinessLogic.Core.Models;
using System.Data.SqlClient;

namespace CodeFirstIOCDemo.Dao.Frameworks
{
    public class CodeFirstIOCDemoContextImpl : DbContext
    {
        private static object[] EmptyParams = new object[] { };

        public CodeFirstIOCDemoContextImpl()
        {
        }

        public CodeFirstIOCDemoContextImpl(SqlConnection conn) : base(conn, true)
        {
        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<MilestoneTemplate> MilestoneTemplates { get; set; }

        public DbSet<MilestoneTemplateItem> MilestoneTemplateItems { get; set; }

        public DbSet<TaskTemplate> TaskTemplates { get; set; }

        public DbSet<Milestone> Milestones { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<TaskTemplateItem> TaskTemplateItems { get; set; }

        public DbSet<ProjectTask> ProjectTasks { get; set; }

        public DbSet<TaskOutput> TaskOutputs { get; set; }

        public DbSet<RoleTemplate> RoleTemplates { get; set; }

        public DbSet<RoleTemplateItem> RoleTemplateItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Comment>().HasMany(m => m.Comments);

            // TODO: 去掉使用动态属性实现的接口，但在数据表里又生成列的问题。
            modelBuilder.Entity<Comment>().HasMany(e => e.Comments);

            modelBuilder.Entity<Permission>().ToTable("Permissions");

            modelBuilder.Entity<Organization>().ToTable("Organizations");

            // TODO: 权限组应该只能跟一个公司挂钩的
            // 下面这个映射是为了解决EF无法正确生成数据库的临时解决方案
            modelBuilder.Entity<Organization>().HasMany(o => o.Roles).WithMany();
            modelBuilder.Entity<Organization>().HasMany(o => o.Employees).WithMany();

            modelBuilder.Entity<Identity>().Map(m =>
            {
                m.Properties(i => new
                {
                    i.Id,
                    i.Name,
                    i.OrganizationId
                });
                m.ToTable("Identities");
            });
            modelBuilder.Entity<Identity>().Property(i => i.Name).IsRequired();
            modelBuilder.Entity<Identity>().HasMany(i => i.Permissions).WithOptional().WillCascadeOnDelete();
            modelBuilder.Entity<Identity>().HasMany(i => i.Roles).WithMany(r => r.Children);

            modelBuilder.Entity<Role>().ToTable("Roles");

            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Employee>().HasMany(e => e.Subordinates);
            modelBuilder.Entity<Employee>().Ignore(e => e.Email);

            modelBuilder.Entity<Setting>().ToTable("Settings");

            modelBuilder.Entity<MilestoneTemplate>().ToTable("MilestoneTemplates");
            modelBuilder.Entity<MilestoneTemplate>().HasMany(m => m.Milestones).WithRequired(m => m.Template).HasForeignKey(m => m.TemplateId);
            modelBuilder.Entity<MilestoneTemplateItem>().ToTable("MilestoneTemplateItems");
            modelBuilder.Entity<TaskTemplate>().ToTable("TaskTemplates");
            modelBuilder.Entity<Milestone>().ToTable("Milestones");
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<TaskTemplateItem>().ToTable("TaskTemplateItems");
            modelBuilder.Entity<TaskTemplateItem>().HasMany(t => t.TaskInput);
            modelBuilder.Entity<TaskTemplateItem>().HasMany(t => t.TaskOutput);
            modelBuilder.Entity<ProjectTask>().ToTable("ProjectTasks");
            modelBuilder.Entity<ProjectTask>().HasMany(t => t.TaskInput);
            modelBuilder.Entity<ProjectTask>().HasMany(t => t.TaskOutput);
            modelBuilder.Entity<TaskOutput>().ToTable("TaskOutputs");
            modelBuilder.Entity<RoleTemplate>().ToTable("RoleTemplates");
            modelBuilder.Entity<RoleTemplateItem>().ToTable("RoleTemplateItems");
        }
    }
}
