using System;
using litehttp;
using litehttp.Extensions;
using litehttp.Http;


namespace LiteServer
{
    class Program
    {
        static void Main(string[] args)
        {
           LiteHttp.Create()
                .Get("/", () => "hello")
                .Get("time", () => DateTime.Now)
                .Use((req, resp) => { } )
                .Static(@"C:\mysite")
                .Listen(port: 80);
        }

    }

    public class InsertIdDto
    {
        public int Id { get; set; }
    }
}
