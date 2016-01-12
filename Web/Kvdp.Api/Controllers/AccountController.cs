using GMK.OperationSystem.WFProxy.Infrastructure;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Net;
using System.Net.Security;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using System.Security.Cryptography;
using System.Web.Security;

namespace Com.Gm.CodeFirstIOCDemo.Api
{
    /// <summary>
    /// Handles login related staff.
    /// </summary>
    [OverrideAuthentication]
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        [HttpPost]
        public bool Login(string username, string password)
        {
            return false;
        }
    }
}