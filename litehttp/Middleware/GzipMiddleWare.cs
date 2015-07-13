using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using litehttp.Framework;

namespace litehttp.Middleware
{
    public class GzipMiddleWare : LiteMiddleWare
    {
        public GzipMiddleWare(LiteMiddleWare next) : base(next)
        {
        }

        public override async Task Use(ILiteContext context)
        {
            await Next.Use(context);
            context.Response.StatusCode = 200;
            var body = context.Response.Body;

            context.Response.Body = new GZipStream(body, CompressionMode.Compress);
        }
    }
}
