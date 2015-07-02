using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace litehttp.Runtime
{
    internal class RequestProcessor
    {
        private readonly LiteHttpServerConfiguration _config;
        private readonly StaticServer _staticServer;

        public RequestProcessor(LiteHttpServerConfiguration config)
        {
            _config = config;
            _staticServer = new StaticServer(config.RootServePath);
        }

        internal async Task ProcessRequestAsync(HttpListenerContext context)
        {
            var req = context.Request;
            var resp = context.Response;

            if (IsStaticRequest(req))
            {
                await ServeStaticResource(req, resp);
                return;
            }

            ////to do remove to-lower use Invariant Compare for Keys
            //var absPath = req.Url.AbsolutePath.ToLower();

            //var executor = _config.GetExecutor(absPath);

            //var type = executor.Item1;
            //var func = executor.Item2;

            //var result = func.DynamicInvoke().ToString();

            //resp.ContentLength64 = result.Length;
            //await resp.OutputStream.WriteAsync(Encoding.Default.GetBytes(result), 0, result.Length);
        }

        private async Task ServeStaticResource(HttpListenerRequest request, HttpListenerResponse response)
        {
            using (var stream = _staticServer.Serve(request.Url))
            {
                if (stream == null)
                {
                    await SentNotFound(response);
                    return;
                }

                using (var respStream =  response.OutputStream)
                {
                    
                    response.StatusCode = (int)HttpStatusCode.OK;
                    await stream.CopyToAsync(respStream);
                }
            }
        }


        private async Task SentNotFound(HttpListenerResponse response)
        {
            using (var stream = new StreamWriter(response.OutputStream))
            {
                var notfound = "File not found.";
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.ContentLength64 = notfound.Length;
                await stream.WriteAsync(notfound);
            }
        }

        private bool IsStaticRequest(HttpListenerRequest req)
        {
            return Path.HasExtension(req.Url.AbsolutePath);
        }
    }
}