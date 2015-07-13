using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using litehttp;
using litehttp.Extensions;
using litehttp.Framework;
using litehttp.Middleware;


namespace LiteServer
{
    class Program
    {
        static void Main(string[] args)
        {
           LiteHttp.Create()
                 .Use<DiagnosticMiddleWare>()
                 .Use<GzipMiddleWare>()
                 .Listen(port: 80);
        }

    }

    public class InsertIdDto : LiteRequest
    {
        public int Id { get; set; }
    }
}
