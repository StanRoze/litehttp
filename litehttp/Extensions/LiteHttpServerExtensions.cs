using litehttp.Middleware;

// ReSharper disable once CheckNamespace
namespace litehttp.Extensions
{
    public static class LiteHttpServerExtensions
    {
        public static LiteHttpServer Use<T>(this LiteHttpServer server) where T : LiteMiddleWare
        {
            server.Middleware.Add<T>();
            return server;
        }
    }
}