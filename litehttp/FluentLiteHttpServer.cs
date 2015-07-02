//using System;
//using System.ComponentModel;
//using System.Diagnostics.Contracts;
//using System.IO;
//using litehttp.Framework;

//namespace litehttp
//{
//    internal class FluentLiteHttpServer : IFluentLiteServer
//    {
//        private readonly LiteHttpServerConfiguration _config;
//        private readonly Router _router = new Router();

//        public FluentLiteHttpServer()
//        {
//            _config = new LiteHttpServerConfiguration();
//        }
//        public void Listen(int port)
//        {
//            var server = new LiteHttpServer(_config);
//            server.Listen(port);
//            Console.WriteLine("Listening");
            
//        }

//        public IFluentLiteServer Get<T>(string path, Func<T> executor)
//        {
//            _router.AddRoute(path, executor);
//            return this;
//        }

//        public IFluentLiteServer Get<T, I>(string path, Func<T, I> executor)
//        {
//            _router.AddRoute(path, executor);
//            return this;
//        }


//        public IFluentLiteServer Post<T, I>(string path, Func<T, I> executor)
//        {
//            return this;
//        }

//        public IFluentLiteServer StaticServe(string path)
//        {
//            Contract.Assert(path != null);

//            if (!Directory.Exists(path))
//            {
//                throw new ArgumentException("Could not find path.", "path");
//            }

//            _config.RootServePath = path;
//            return this;
//        }
//    }
//}
