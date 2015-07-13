using System.IO;

namespace litehttp.Framework
{
    public interface ILiteResponse
    {
        int StatusCode { get; set; }
        Stream Body { get; set; }
    }
}