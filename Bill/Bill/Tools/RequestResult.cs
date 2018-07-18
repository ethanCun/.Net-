using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
//引入JsonMediaTypeFormatter命名空间
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
//引入IHttpActionResult命名空间
using System.Web.Http.Results;

namespace Bill.Tools
{
    public class RequestResult : IHttpActionResult
    {
        object _value;
        HttpRequestMessage _request;

        public RequestResult(object value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage() {

                Content = new ObjectContent(typeof(object), _value, new JsonMediaTypeFormatter()),
                RequestMessage = _request
            };

            return Task.FromResult(response);
        }
    }
}