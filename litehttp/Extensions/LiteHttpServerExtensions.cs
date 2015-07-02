using System;
using System.Diagnostics.Contracts;
using System.IO;
using litehttp.Http;
using Microsoft.Owin;

namespace litehttp.Extensions
{
    public static class LiteHttpServerExtensions
    {
        public static ILiteServer Use(this ILiteServer server, Action<LiteRequest, LiteResponse> middleware)
        {
            server.Router.Use(middleware);
            return server;
        }
    }
}