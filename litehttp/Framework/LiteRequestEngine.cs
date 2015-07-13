using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using litehttp.Middleware;

namespace litehttp.Framework
{
    internal class LiteRequestEngine
    {
        private readonly LiteMiddleWare _seedWare;
        private readonly LiteServerConfiguration _config;

        public LiteRequestEngine(LiteMiddleWare seedWare)
        {
            _seedWare = seedWare;
        }

        internal async Task ProcessRequestAsync(HttpListenerContext context)
        {
            var litecontext = LiteContext.Create(context);
            await _seedWare.Use(litecontext);
            context.Response.Close();
        }
    }
}