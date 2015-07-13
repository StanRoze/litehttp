namespace litehttp.Framework
{
    public class LiteContext : ILiteContext
    {
        public ILiteRequest Request { get; private set; }
        public ILiteResponse Response { get; private set; }

        internal static LiteContext Create(System.Net.HttpListenerContext context)
        {
            return new LiteContext()
            {
                Request = new LiteRequest(context.Request),
                Response = new LiteResponse(context.Response)
            };
        }
    }
}