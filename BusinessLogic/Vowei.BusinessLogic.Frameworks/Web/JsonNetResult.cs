using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CodeFirstIOCDemo.BusinessLogic.Core;
using CodeFirstIOCDemo.BusinessLogic.Core.Extensions;

namespace CodeFirstIOCDemo.BusinessLogic.Frameworks.Web
{
    public class JsonNetResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            //if ((this.JsonRequestBehavior == System.Web.Mvc.JsonRequestBehavior.DenyGet) && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            //{
            //    throw new InvalidOperationException(MvcResources.JsonRequest_GetNotAllowed);
            //}
            var response = context.HttpContext.Response;

            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data != null)
            {
                // If you need special handling, you can call another form of SerializeObject below
                //var serializedObject = JsonConvert.SerializeObject(Data, Formatting.Indented);
                var serializedObject = Data.ToJson();
                response.Write(serializedObject);
            }
        }
    }
}
