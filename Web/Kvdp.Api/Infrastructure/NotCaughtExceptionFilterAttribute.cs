using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;

namespace GMK.OperationSystem.WFProxy.Infrastructure
{
    public class NotCaughtExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);
            var routeData = actionExecutedContext.ActionContext.ControllerContext.RouteData;
            var logText = string.Format(" controller: {0}, action: {1}\n{2}\n{3}\n", routeData.Values["controller"], routeData.Values["action"], actionExecutedContext.Exception.Message, actionExecutedContext.Exception.ToString());
            //LogHelper.LogError(logText);
            // var result = new AjaxReturnInfo("系统繁忙，请稍候重试");
            // actionExecutedContext.Response = new HttpResponseMessage { Content = new ByteArrayContent(Encoding.UTF8.GetBytes(result.ToJavaScriptJson())), StatusCode = HttpStatusCode.InternalServerError };
        }
    }
}