using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using litehttp;

namespace LiteServer
{
    class Program
    {
        static void Main(string[] args)
        {
           LiteHttp.Create()
                .Get("/", () => "hello")
                .Get("time", () => DateTime.Now)
                .StaticServe(@"C:\mysite")
                .Listen(80);
        }
    }

   
}
