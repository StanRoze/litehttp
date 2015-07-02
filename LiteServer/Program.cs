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
                .Use((req, res) => res.Ok() )
                .Listen(port: 80);
        }

    }

    public class InsertIdDto : LiteRequest
    {
        public int Id { get; set; }
    }
}
