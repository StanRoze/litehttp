using litehttp.Http;

namespace litehttp.Framework
{
    internal class LiteResponseConverter
    {
        internal static LiteResponse FromHttpListenerResponse(System.Net.HttpListenerRequest req)
        {
            return new LiteResponse();
        }
    }
}