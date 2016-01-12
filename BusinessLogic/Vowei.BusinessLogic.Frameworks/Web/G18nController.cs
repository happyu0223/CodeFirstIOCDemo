using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CodeFirstIOCDemo.BusinessLogic.Core;
using CodeFirstIOCDemo.BusinessLogic.Core.Interfaces;
using CodeFirstIOCDemo.BusinessLogic.Core.Models;

namespace CodeFirstIOCDemo.BusinessLogic.Frameworks.Web
{
    public class G18nController : Controller
    {
        public G18nController()
            : this(Default.Security.OrganizationId)
        {
        }

        public G18nController(int oid)
        {
            OrganizationId = oid;
            ViewBag.OrganizationId = oid;
        }


        protected bool ViewExists(string name)
        {
            ViewEngineResult result = ViewEngines.Engines.FindView(ControllerContext, name, null);
            return (result.View != null);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (User.Identity.IsAuthenticated
                && !(RouteData.Values["controller"].ToString() == "Account"
                && RouteData.Values["action"].ToString() == "LogOff"))
            {
                // ViewBag.CurrentEmployee = CurrentEmployee();
            }
        }

        protected int OrganizationId { get; set; }

        protected Employee CurrentEmployee()
        {
            throw new NotImplementedException();
            //if (HttpContext.User.Identity.IsAuthenticated)
            //{
            //    var name = HttpContext.User.Identity.Name;
            //    var users = AclHelper.GetUsers();
            //    return users.SingleOrDefault(e => e.Name == name);
            //}
            //else
            //{
            //    return null;
            //}
        }

        private ITranslator _translator;
        protected ITranslator Translator
        {
            get
            {
                if (_translator == null)
                    _translator = AspTranslator.CreateFrom(Request);

                return _translator;
            }
        }

        public string T(string message)
        {
            return Translator.T(message);
        }

        public string T(DateTime value)
        {
            return Translator.T(value);
        }

        public string T(double value)
        {
            return Translator.T(value);
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult { Data = data, ContentType = contentType, ContentEncoding = contentEncoding, JsonRequestBehavior = behavior };
        }
    }
}
