using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace litehttp
{
    public static class LiteHttp
    {
        public static ILiteHttpServer Create(LiteHttpServerConfiguration configuration)
        {
            return new LiteHttpServer(configuration);
        }

        public static ILiteHttpServer Create()
        {
            return new LiteHttpServer();
        }

    }

    public static class LiteHttpServerExtensions
    {
        public static ILiteHttpServer Get<T>(this ILiteHttpServer server, string path, Func<T> executor)
        {
            server.Configuration.AddRoute(path, executor);
            return server;
        }

        public static ILiteHttpServer StaticServe(this ILiteHttpServer server, string path)
        {
            Contract.Assert(path != null);

            if (!Directory.Exists(path))
            {
                throw new ArgumentException("Could not find path.", "path");
            }

            server.Configuration.RootServePath = path;
            return server;
        }
    }
}
