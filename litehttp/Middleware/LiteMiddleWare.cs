using System.Threading.Tasks;
using litehttp.Framework;

namespace litehttp.Middleware
{
    public abstract class LiteMiddleWare
    {
        public LiteMiddleWare Next { get; private set; }

        protected LiteMiddleWare(LiteMiddleWare next)
        {
            Next = next;
        }

        public abstract Task Use(ILiteContext context);

        public static LiteMiddleWare Empty
        {
            get
            {
                return new EmptyMiddleWare(null);
            }
        }
    }
}
