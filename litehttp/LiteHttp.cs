using litehttp.Runtime;

namespace litehttp
{
    public static class LiteHttp
    {
        public static ILiteServer Create(LiteServerConfiguration configuration)
        {
            return new LiteHttpServer(configuration);
        }

        public static ILiteServer Create()
        {
            return new LiteHttpServer();
        }

    }
}
