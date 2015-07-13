using litehttp.Framework;

namespace litehttp
{
    public static class LiteHttp
    {
        public static LiteHttpServer Create(LiteServerConfiguration configuration)
        {
            return new LiteHttpServer(configuration);
        }

        public static LiteHttpServer Create()
        {
            return new LiteHttpServer();
        }

    }
}
