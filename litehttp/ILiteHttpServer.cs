namespace litehttp
{
    public interface ILiteHttpServer
    {
        LiteHttpServerConfiguration Configuration { get; }
        void Listen(int port);
    }
}