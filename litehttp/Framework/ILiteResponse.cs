using System.IO;
using System.Threading.Tasks;

namespace litehttp.Framework
{
    public interface ILiteResponse
    {
        int StatusCode { get; set; }
        Stream Body { get; set; }
        Task CloseAsync();
    }
}