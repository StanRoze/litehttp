namespace litehttp.Framework
{
    public interface ILiteContext
    {
        ILiteRequest Request { get; }
        ILiteResponse Response { get; }
    }
}