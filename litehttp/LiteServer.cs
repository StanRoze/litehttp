using System;
using System.Diagnostics.Contracts;
using System.Net;
using System.Threading.Tasks;
using litehttp.Runtime;

namespace litehttp
{
    internal class LiteHttpServer : ILiteHttpServer
    {
        protected readonly LiteHttpServerConfiguration Config;
        protected RequestProcessor Mapper;
        protected HttpListener Listener;

        public LiteHttpServer(LiteHttpServerConfiguration config)
        {
            Config = config;
            InitializeFromConfig();
        }

        private void InitializeFromConfig()
        {
            Mapper = new RequestProcessor(Config);
        }

        public LiteHttpServer() : this(LiteHttpServerConfiguration.Default)
        {
            
        }

        public void Listen(int port)
        {
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