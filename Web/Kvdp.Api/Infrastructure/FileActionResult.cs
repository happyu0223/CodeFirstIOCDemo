using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace GMK.OperationSystem.WFProxy.Infrastructure
{
    public class FileActionResult : IHttpActionResult
    {
        public Stream Stream { get; set; }
        public string FileName { get; set; }

        public string MediaType { get; set; }

        public string UserAgent { get; set; }


        public Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage 
            { 
                Content = new StreamContent(Stream)
            };
            if (UserAgent.IndexOf("MSIE", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileNameStar = FileName };
            }
            else
            {
                response.Content.Headers.Add("Content-Disposition", string.Format("attachment; filename=\"{0}\"", FileName));
            }
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(MediaType);
            return Task.FromResult(response);
        }
    }
}