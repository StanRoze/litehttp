using litehttp.Runtime;
using System;
using System.Collections.Generic;

namespace litehttp
{
    public interface ILiteServer
    {
        LiteServerConfiguration Configuration { get; }
        ILiteRouter Router { get; }
        void Listen(int port = 80);
    }

    public interface ILiteRouter
    {
        void Use(Action<Http.LiteRequest, Http.LiteResponse> middleware);
        IEnumerable<Action<Http.LiteRequest, Http.LiteResponse>> GetMiddleWare();
    }
}