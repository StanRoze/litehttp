using System;
using System.Threading.Tasks;
using litehttp.Framework;

namespace litehttp.Middleware
{
    internal class EmptyMiddleWare : LiteMiddleWare
    {
        public EmptyMiddleWare(LiteMiddleWare next)
            : base(next)
        {
        }

        public override Task Use(ILiteContext context)
        {
            //do nothing
            return Task.FromResult("Ok");
        }
    }
}