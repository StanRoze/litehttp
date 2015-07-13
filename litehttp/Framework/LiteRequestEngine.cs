using System;
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
            try
            {
                Console.WriteLine("[LiteServer] Processing request from {0}", context.Request.Url);
                var litecontext = LiteContext.Create(context);
                try
                {
                    await _seedWare.Use(litecontext);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                await litecontext.Response.CloseAsync();
            }
            catch (Exception ex)
            {
                context.Response.Abort();
            }
       }
    }
}