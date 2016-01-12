using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace GMK.OperationSystem.WFProxy.Infrastructure
{
    public class UnauthorizedWithTextActionResult : UnauthorizedResult
    {

        public UnauthorizedWithTextActionResult(IEnumerable<AuthenticationHeaderValue> challenges, ApiController controller)
            : base(challenges, controller)
        {
        }

        public UnauthorizedWithTextActionResult(IEnumerable<AuthenticationHeaderValue> challenges, HttpRequestMessage request)
            : base(challenges, request)
        {
        }

        public string Message { get; set; }

        public override async Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            var task = await base.ExecuteAsync(cancellationToken);
            // task.Content = new ByteArrayContent(Encoding.UTF8.GetBytes(new AjaxReturnInfo(Message).ToJavaScriptJson()));
            return task;
        }
    }
}