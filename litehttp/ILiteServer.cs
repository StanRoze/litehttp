using litehttp.Runtime;

namespace litehttp
{
    public interface ILiteServer
    {
        LiteServerConfiguration Configuration { get; }
        void Listen(int port = 80);
    }
}