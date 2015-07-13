using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using litehttp.Framework;
using litehttp.Middleware;

namespace litehttp
{
    public class LiteHttpServer 
    {
        private LiteRequestEngine Mapper;
        protected HttpListener Listener;
        
        public LiteServerConfiguration Configuration { get; private set; }
        public MiddleWareCollection Middleware { get; private set; }

        public LiteHttpServer(LiteServerConfiguration config)
        {
            Configuration = config;
            Middleware = new MiddleWareCollection();
        }

        public LiteHttpServer() : this(LiteServerConfiguration.Default)
        {
            
        }

        public void Listen(int port = 80)
        {
            //create middle ware
            Mapper = new LiteRequestEngine(Middleware.Create());

            using (Listener = new HttpListener())
            {
                Listener.Prefixes.Add(string.Format("http://localhost:{0}/", port));
                Listener.Start();
                Console.WriteLine("[LiteServer] Listening on {0}", Listener.Prefixes.FirstOrDefault());
                OffLoadRequestThread();
                WaitForShutDown();
            }
            
        }

        private void WaitForShutDown()
        {
            Console.ReadKey();
        }

        private void OffLoadRequestThread()
        {
            Task.Factory.StartNew(RequestLoopAsync);
        }

        private async void RequestLoopAsync()
        {
            Contract.Assert(Listener != null);

            if (!Listener.IsListening)
            {
                return;
            }

            var context = await Listener.GetContextAsync();
            OffLoadRequestThread();
            ProcessIncomingRequest(context);

        }

        private void ProcessIncomingRequest(HttpListenerContext context)
        {
            //process request on another task.
            Task.Factory.StartNew( () => Mapper.ProcessRequestAsync(context));
        }
        
    }
}