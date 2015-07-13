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
        }
    }
}
