using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using litehttp.Middleware;

namespace LiteServer
{
    internal class DiagnosticMiddleWare : LiteMiddleWare
    {
        public DiagnosticMiddleWare(LiteMiddleWare next) : base(next)
        {
        }

        public override async Task Use(litehttp.Framework.ILiteContext context)
        {
            var watch = Stopwatch.StartNew();
            await Next.Use(context);
            watch.Stop();
            Console.WriteLine("Finished: {0}ms", watch.Elapsed.TotalMilliseconds);
        }
    }
}
