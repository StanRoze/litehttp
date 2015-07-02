using System;
using System.Diagnostics.Contracts;
using System.Net;
using System.Threading.Tasks;
using litehttp.Framework;

namespace litehttp
{
    internal class LiteHttpServer : ILiteHttpServer
    {
        protected LiteRequestEngine Mapper;
        protected HttpListener Listener;

        public LiteHttpServerConfiguration Configuration { get; private set; }

        public LiteHttpServer(LiteHttpServerConfiguration config)
        {
            Configuration = config;
        }

        private void InitializeFromConfig()
        {
            Mapper = new LiteRequestEngine(Configuration);
        }

        public LiteHttpServer() : this(LiteHttpServerConfiguration.Default)
        {
            
        }

        public void Listen(int port)
        {
            InitializeFromConfig();
            using (Listener = new HttpListener())
            {
                Listener.Prefixes.Add(string.Format("http://localhost:{0}/", port));
                Listener.Start();

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
            //process request on another thread.
            Task.Factory.StartNew( () => Mapper.ProcessRequestAsync(context));

        }



      
    }
}