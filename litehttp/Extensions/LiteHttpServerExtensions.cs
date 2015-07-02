using System;
using System.Diagnostics.Contracts;
using System.IO;
using litehttp.Http;

namespace litehttp.Extensions
{
    public static class LiteHttpServerExtensions
    {
        public static ILiteServer Get<T>(this ILiteServer server, string path, Func<T> executor)
        {
            server.Configuration.AddRoute(path, executor);
            return server;
        }

        public static ILiteServer Static(this ILiteServer server, string path)
        {
            Contract.Assert(path != null);

            if (!Directory.Exists(path))
            {
                throw new ArgumentException("Could not find path.", "path");
            }

            server.Configuration.RootServePath = path;
            return server;
        }

        public static ILiteServer Post<T,I>(this ILiteServer server, string path, Func<T, I> executor)
        {
            return server;
        }

        public static ILiteServer Post<T>(this ILiteServer server, string path, Func<T, LiteResponse> executor)
        {
            return server;
        }

        public static ILiteServer Use(this ILiteServer server, Action<LiteRequest, LiteResponse> middleware)
        {
            return server;
        }

        public static ILiteServer Use(this ILiteServer server, string path, Action<LiteRequest, LiteResponse> middleware)
        {
            return server;
        }
    }
}