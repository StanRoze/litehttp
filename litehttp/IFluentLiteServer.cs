using System;

namespace litehttp
{
    public interface IFluentLiteServer : ILiteHttpServer
    {
        IFluentLiteServer Get<T>(string path, Func<T> executor);
        IFluentLiteServer Post<T, I>(string path, Func<T, I> executor);
        IFluentLiteServer StaticServe(string path);
    }
}