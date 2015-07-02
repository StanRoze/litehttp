using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using litehttp.Runtime;

namespace litehttp.Framework
{
    internal class LiteRequestEngine
    {
        private readonly LiteServerConfiguration _config;
        private readonly StaticServer _staticServer;
        private LiteServerConfiguration Configuration;
        private ILiteRouter Router;

        public LiteRequestEngine(LiteServerConfiguration config)
        {
            _config = config;
            _staticServer = new StaticServer(config.RootServePath);
        }

        public LiteRequestEngine(LiteServerConfiguration Configuration, ILiteRouter Router)
        {
            // TODO: Complete member initialization
            this.Configuration = Configuration;
            this.Router = Router;
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

            var liteRequest = LiteRequestConverter.FromHttpListenerRequest(req);
            var liteResponse = LiteResponseConverter.FromHttpListenerResponse(req);

            foreach (var middleWare in Router.GetMiddleWare())
            {
                middleWare(liteRequest, liteResponse);
            }

            ////to do remove to-lower use Invariant Compare for Keys
            //var absPath = req.Url.AbsolutePath.ToLower();

            //var executor = _config.GetExecutor(absPath);

            //var type = executor.Item1;
            //var func = executor.Item2;

            

            //resp.ContentLength64 = result.Length;
            //await resp.OutputStream.WriteAsync(Encoding.Default.GetBytes(result), 0, result.Length);

            resp.StatusCode = liteResponse.StatusCode;
            var result = "stan";
            resp.ContentLength64 = result.Length;
            await resp.OutputStream.WriteAsync(Encoding.Default.GetBytes(result), 0, result.Length);
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