using System;
using System.Diagnostics.Contracts;
using System.Net;
using System.Threading.Tasks;
using litehttp.Framework;

namespace litehttp.Runtime
{
    internal class LiteHttpServer : ILiteServer
    {
        protected LiteRequestEngine Mapper;
        protected HttpListener Listener;
        public ILiteRouter Router { get; private set; }

        public LiteServerConfiguration Configuration { get; private set; }

        public LiteHttpServer(LiteServerConfiguration config)
        {
            Configuration = config;
            Router = new Router();
        }

        private void InitializeFromConfig()
        {
            Mapper = new LiteRequestEngine(Configuration, Router);
        }

        public LiteHttpServer() : this(LiteServerConfiguration.Default)
        {
            
        }

        public void Listen(int port = 80)
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
            //process request on another task.
            Task.Factory.StartNew( () => Mapper.ProcessRequestAsync(context));
        }



        
    }
}