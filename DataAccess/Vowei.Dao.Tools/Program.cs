using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using CodeFirstIOCDemo.BusinessLogic.Core;
using CodeFirstIOCDemo.BusinessLogic.Core.Models;
using XGetoptCS;
using CodeFirstIOCDemo.BusinessLogic.Core.Extensions;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.Dao.Frameworks;

namespace CodeFirstIOCDemo.Dao.Tools
{
    class SetupOptions
    {
        public string BossUserName { get; set; }

        public string BossEmail { get; set; }

        public string BossPassword { get; set; }

        public string OrganizationName { get; set; }

        public bool DropAndCreateDatabase { get; set; }

        public string Script { get; set; }

        public string ConnectionString { get; set; }
    }

    class BackupOptions
    {
        public string JsonOutput { get; set; }
    }

    class Program
    {
        static void SetupUsage()
        {
            Console.WriteLine(@"CodeFirstIOCDemo.tools setup
Descriptions：
    -h  Print this usage help message.");
        }

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Usage();
                return;
            }

            var restArgs = new string[args.Length - 1];
            Array.Copy(args, 1, restArgs, 0, restArgs.Length);
            if (args[0] == "setup")
            {
                Setup(restArgs);
            }
        }

        private static void Usage()
        {
            Console.WriteLine("Usage: CodeFirstIOCDemo.tools setup");
        }

        private static void Setup(string[] args)
        {
            Database.DefaultConnectionFactory = new SqlConnectionFactory("System.Data.SqlClient");

            using (var context = new CodeFirstIOCDemoContextImpl())
            {
#if !DEBUG
            try
            {
#endif
                new DropCreateDatabaseAlways<CodeFirstIOCDemoContextImpl>().InitializeDatabase(context);
#if !DEBUG
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e);
            }
#endif
            }
        }
        
        private static void CreateUsers(SetupOptions opt, Organization org)
        {
            MembershipCreateStatus createStatus;
            Membership.CreateUser(opt.BossUserName, opt.BossPassword, opt.BossEmail, null, null, true, null, out createStatus);
        }

        static SetupOptions ParseSetupOption(string[] args)
        {
            var parser = new XGetopt();
            char c = '\0';
            var opt = new SetupOptions();
            while ((c = parser.Getopt(args.Length, args, "c:")) != '\0')
            {
                switch (c)
                {
                    case 'h':
                    default:
                        SetupUsage();
                        return null;
                }
            }

            opt.DropAndCreateDatabase = true;
            return opt;
        }
    }
}
